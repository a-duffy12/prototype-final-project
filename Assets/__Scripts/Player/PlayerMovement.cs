using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;

    public float speed = 12f;
    public float grav = -9.81f; //gravity
    public float jumpHt = 3f; //jump height    

    Vector3 vel; //velocity
    bool isGrounded;

    public Transform groundTest;
    public float groundDist = 0.2f; //radius of ground check
    public LayerMask groundMask; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundTest.position, groundDist, groundMask); //tests is player is on the ground
        if(isGrounded && vel.y < 0){ //sets velocity to -2 when on the ground 
            vel.y = -2f; //brings the player down faster
        }

        float x = Input.GetAxis("Horizontal"); //creates variables for axis inputs
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //moves player based on direction they are facing 

        control.Move(move * speed * Time.deltaTime); //uses character controller to move player

        if(Input.GetButtonDown("Jump") && isGrounded){ //if player in on the ground and jump key is pressed
            vel.y = Mathf.Sqrt(jumpHt * -2f * grav); //adds velocity to jump
        }

        vel.y += grav * Time.deltaTime; //gravity pulls player down

        control.Move(vel * Time.deltaTime); //moves player controller        
    }
}
