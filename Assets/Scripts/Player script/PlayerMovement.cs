    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
   public float speed = 12f;
   Vector3 velocity;
   public float gravity = -9.81f;
    private Transform groundCheck; 
   public float groundDistance = 0.4f;
   public LayerMask groundMask;
   public float jumpHeight = 3f;

   bool isGrounded;   

private void Start() {
groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
}
private void Update() {

isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
   if(isGrounded && velocity.y < 0){
    velocity.y = -2f;
   }

   if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
   }
   float horizontalInput = Input.GetAxis("Horizontal");
   float verticalInput = Input.GetAxis("Vertical"); 
      // Vector3 move1 = new Vector3 (horizontalInput,0,verticalInput);
   Vector3 move = transform.right * horizontalInput + transform.forward *verticalInput;
  controller.Move(move * speed * Time.deltaTime);
      //controller.Move(move1 * speed * Time.deltaTime);
      velocity.y += gravity * Time.deltaTime;

      controller.Move(velocity * Time.deltaTime);
   }

}
