using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;
    public Rigidbody rb;
    public float jumpForce = 9;

    bool canJump = true;

    private void OnCollisionEnter(Collision collision)
    {
        Jump();
    }
    void Jump()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.jump);
        int i = Random.Range(0, 3);
        anim.SetTrigger("Jump" + i);
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);// jump tu up
            canJump = false;
            Invoke("ResetCanJump", .1f); // Aufruf der Funktion nach einer bestimmten Zeit.
        }
    }
    void ResetCanJump()
    {
        canJump = true;
    }


}
