using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerGalaw : MonoBehaviour
{  private GameObject movingPlatform;
    private bool isOnPlatform = false;
    private Vector3 lastPlatformPosition;
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
    public float jumpPadForce = 0f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator animation;
    public bool playAnimation = true;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "death")
        {
            defaultHP = defaultHP - 100f;
            print("The collision is working");
        }

    }
void Update()
{
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    if (isGrounded && velocity.y < 0)
    {
        grounded = 1;
        velocity.y = -2f;
        useTime = 0; // Reset the double jump counter
    }
    else
    {
        grounded = 0;
    }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        bool isMoving = (x != 0 || z != 0);
    
        // Update the animation parameter based on whether the character is moving or not
        animation.SetBool("isRun", !isMoving);
        animation.SetBool("isRun", isMoving);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(talonTaas * -2 * gravity);

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 30f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        switch(hit.gameObject.tag)
        {
            case "JumpPad":
                gravity = -13f;
                velocity.y = Mathf.Sqrt(jumpPadForce * -2 * gravity);
                useTime++;
                break;
            case "JumpPadAutomatic":
                gravity = -13f;
                velocity.y = Mathf.Sqrt(40f * -2 * gravity);
                useTime++;
                break;
            case "JumpPadAutomatic30":
                gravity = -13f;
                velocity.y = Mathf.Sqrt(30f * -2 * gravity);
                useTime++;
                break;
            case "JumpPadAutomatic20":
                gravity = -13f;
                velocity.y = Mathf.Sqrt(20f * -2 * gravity);
                useTime++;
                break;
            case "Ground":
                gravity = -9.8f;
                talonTaas = 2f;
                break;
        }
    }
}
