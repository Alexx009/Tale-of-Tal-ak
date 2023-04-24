 using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerGalaw : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float talonTaas = 2f;
    public float defaultHP = 100f;
    public float timer = 3;
    public float seconds = 1;
    public int useTime = 0;
    public int grounded = 0;
    public GameObject enemy;
    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "death")
        {
            defaultHP = defaultHP - 100f;
            print("The collision is working");
        }

    }
    void Start()
    {

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            grounded = 1;
            velocity.y = -2f;
        }
        else
        {
            grounded = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(talonTaas * -2 * gravity);

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            speed = 30f;

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    
}
