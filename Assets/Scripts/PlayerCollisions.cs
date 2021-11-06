using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public GameObject splashEffect;
    public ParticleSystem collideEffect;


    public GameObject superTrail;
    public int SuperModeAfter = 2;
    int currentSuperMode = 0;
    bool isSuperMode = false;

    private void Start()
    {
        SetSuperMode(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Check"))
        {
           // GameManager.Instance.levelManager.NextLevel();
            other.GetComponentInParent<Stage>().Hide();
            currentSuperMode++;
            if(currentSuperMode >= SuperModeAfter)
            {
                SetSuperMode(true);
            }

        }

    }

    void SetSuperMode(bool value)
    {
        if (value == isSuperMode)
            return;
        isSuperMode = value;
        superTrail.SetActive(isSuperMode);
        if(!isSuperMode)
        {
            currentSuperMode = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Beginn of effect
          Vector3 collidePoint = collision.GetContact(0).point;
          GameObject spl = Instantiate(splashEffect, collidePoint + new Vector3(0,.1f,0), splashEffect.transform.rotation);
          spl.transform.SetParent(collision.transform);

          collideEffect.Play();
        // End of Effect 

        if (isSuperMode)
        {
            Debug.Log(collision.gameObject.GetComponentInParent<Stage>());
            collision.gameObject.GetComponentInParent<Stage>().Hide();
            SetSuperMode(false);
        }

        SetSuperMode(false);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();

        }
    }
    void Die()
    {

        Debug.Log("Die");
        GameManager.Instance.uiManager.Lose();
    }

}
