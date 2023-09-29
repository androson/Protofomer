using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpOne : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRB;
    //[SerializeField] private float jumpSpeed;
    //private float gravityScale;
    //[SerializeField] private float gravityMultiplier;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
        
    [SerializeField] private float jumpApex;
    [SerializeField] private float jumpDuration;


    // Start is called before the first frame update
    void Start()
    {
        //gravityScale = playerRB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
       //Debug.Log("gravityScale" + gravityScale);
       //Debug.Log("gravityMultiplier" + gravityMultiplier);
       //Debug.Log("playerRB.velocity.y" + playerRB.velocity.y);

    }


    private void Movement()
    {
        // Gets left and right movement input on x axis from horizontal keys be it arrow or A D,
        float inputx = Input.GetAxis("Horizontal");

        // makes velocity of horizontal movement into walkspeed while freezing vertical movement with velocity.y
        playerRB.velocity = new Vector2(inputx * walkSpeed, playerRB.velocity.y);
        
        //if input is great than 0face right 
        if (inputx> 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        // if input is great than face left 
        if (inputx < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    private void Jump()
    {
        // defining gravity by multiplying -2 into max jump hieght divided by jumpduration multiplied by jumpduration
        float grav = -2 * jumpApex / (jumpDuration * jumpDuration);
        
        

        //Debug.Log("playerRB velocity y" + playerRB.velocity.y); works

        // when player jumps Velocity.y is positive and when he is descending it goes negative 
        //so when he is descending gravity is doubled to make fall faster 

        if (playerRB.velocity.y < -0.1)
        {
            grav = grav * 2; // not workin
            //Debug.Log("i work"); works 
        }
        
        float velo = -grav * jumpDuration;

        Physics2D.gravity = new Vector2(0, grav);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //jump up 
            playerRB.velocity = Vector2.up * velo;

            //playerRB.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

            
            //
            //else
            //{
            //    playerRB.gravityScale = gravityScale;
            //}
        }
        
       
    }
}
