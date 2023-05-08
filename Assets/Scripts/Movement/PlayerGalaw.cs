using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerGalaw : MonoBehaviour
{  
    public AudioSource audioSource;
    public AudioSource audioSource1;
    public AudioClip jumpSfx;
    public AudioClip runningSfx;
    private GameObject movingPlatform;
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
    private float x;
    private float z;
    private bool isPlayingAudio = false;

    public new Animator animation;
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
    bool canJump = !Physics2D.Raycast(transform.position, -Vector2.up, 1f, (int)90f, groundMask);
    
    if (isGrounded && velocity.y < 0)
    {
        grounded = 1;
        velocity.y = -2f;
        useTime = 0; // Reset the double jump counter

        bool isMoving = (x != 0 || z != 0);
        // Update the animation parameter based on whether the character is moving or not
        animation.SetBool("isRun", !isMoving);
        animation.SetBool("isRun", isMoving);
        animation.SetBool("isDead", false);
        
    }
    else
    {
        grounded = 0;
        animation.SetBool("isDead", true);
    }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            // Only play the jump sound effect if it is not already playing
            if (!isPlayingAudio)
            {
                audioSource.PlayOneShot(jumpSfx);
                isPlayingAudio = true;
                Invoke("StopAudio", jumpSfx.length); // Stop the audio after it has finished playing
            }
            velocity.y = Mathf.Sqrt(talonTaas * -2 * gravity);
        }

        if (Input.GetButton("Horizontal")){
            if (!isPlayingAudio)
            {
                audioSource1.PlayOneShot(runningSfx);
                isPlayingAudio = true;
                Invoke("StopAudio", runningSfx.length); // Stop the audio after it has finished playing
            }
        }
        if (Input.GetButton("Vertical")){
            if (!isPlayingAudio)
            {
                audioSource1.PlayOneShot(runningSfx);
                isPlayingAudio = true;
                Invoke("StopAudio", runningSfx.length); // Stop the audio after it has finished playing
            }
        }


        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     speed = 30f;
        // }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        switch(hit.gameObject.tag)
        {
            case "JumpPad":
                audioSource.PlayOneShot(jumpSfx);
                gravity = -13f;
                velocity.y = Mathf.Sqrt(jumpPadForce * -2 * gravity);
                useTime++;
                break;
            case "JumpPadAutomatic":
                audioSource.PlayOneShot(jumpSfx);
                gravity = -13f;
                velocity.y = Mathf.Sqrt(40f * -2 * gravity);
                useTime++;
                break;
            case "JumpPadAutomatic30":
                audioSource.PlayOneShot(jumpSfx);
                gravity = -13f;
                velocity.y = Mathf.Sqrt(30f * -2 * gravity);
                useTime++;
                break;
            case "JumpPadAutomatic20":
                audioSource.PlayOneShot(jumpSfx);
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

    private void StopAudio()
    {
        // Reset the flag to allow the audio clip to be played again
        isPlayingAudio = false;
    }
}
