using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust this to control the speed of rotation

    void Update()
    {
        // Rotate the object on the y-axis at a slow speed
        transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
    }
}
