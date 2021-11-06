using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    public float speed = 25;

    Vector2 lastMousePos;

    private void Update()
    {
        if(!GameManager.Instance.isGameOn)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;

            if(lastMousePos == Vector2.zero)
            {
                lastMousePos = currentMousePos;
            }

            Vector2 delta = currentMousePos - lastMousePos;
            transform.Rotate(new Vector3(0, 1, 0), -delta.x * speed * Time.deltaTime);
            lastMousePos = currentMousePos;

        }
        if (Input.GetMouseButtonUp(0))
        {
            lastMousePos = Vector3.zero;
        }
    }
}
