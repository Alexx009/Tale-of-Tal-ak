using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public int maxCollisions = 2;
    private int numCollisions = 0;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        SetColor();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            numCollisions++;

            if (numCollisions > maxCollisions)
            {
                Destroy(gameObject);
            }
            else
            {
                SetColor();
            }
        }
    }

    private void SetColor()
    {
        if (numCollisions == 0)
        {
            rend.material.color = Color.green;
        }
        else if (numCollisions == 1)
        {
            rend.material.color = Color.yellow;
        }
        else if (numCollisions == 2)
        {
            rend.material.color = Color.red;
        }
     
    }
}