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

    //[SerializeField] private float runSpeed;
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private float currentMovementSpeed;

    bool isGrounded;
    [SerializeField] private float jumpApex;
    [SerializeField] private float jumpDuration;

    float timeMovement = 0f;

    bool crystalRed;
    bool crystalBlue;


    // Start is called before the first frame update
    void Start()
    {
        //gravityScale = playerRB.gravityScale;
        GameEvents.current.onPickUpRedCrystal += PickUpRedCrystal;
        GameEvents.current.onPickUpBlueCrystal += PickUpBlueCrystal;
    }

    private void PickUpRedCrystal()
    {
        crystalRed = true;

        Debug.Log("CrystalRed" + crystalRed);
    }

    private void PickUpBlueCrystal()
    {
        crystalBlue = true;

        Debug.Log("crystalBlue" + crystalBlue);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    #region Movement
    private void Movement()
    {
        // Gets left and right movement input on x axis from horizontal keys be it arrow or A D,
        float inputx = Input.GetAxis("Horizontal");

        //if player pressing horizontal keys then move
        if (inputx != 0)
        {
            //allows current movespeed to be controlled by animation curve in inspector
            currentMovementSpeed = movementCurve.Evaluate(timeMovement);
            timeMovement += Time.deltaTime;

            //.drag is for deceleration so making it 0 when character moves
            playerRB.drag = 0f;

            // makes velocity of horizontal movement into walkspeed while freezing vertical movement with velocity.y
            playerRB.velocity = new Vector2(inputx * currentMovementSpeed, playerRB.velocity.y);

            //if input is great than 0face right 
            if (inputx > 0)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            // if input is great than face left 
            if (inputx < 0)
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        else
        {
            timeMovement = 0f;
            //Decelerates the player a bit when player is not pressing horizontal keys
            playerRB.drag = 2f;
            //playerRB.velocity = new Vector2(walkSpeed )
        }


        //Debug.Log("playerRB.velocity.x" + playerRB.velocity.x);
        //Debug.Log("playerRB.drag" + playerRB.drag);
    }
    #endregion

    #region Jump

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            //jump up based on velocity provided by formula 
            playerRB.velocity = Vector2.up * velo;

        }

    }

    #endregion

    #region Ground Check
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            Debug.Log("isGrounded" + isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
            Debug.Log("isGrounded" + isGrounded);
        }
    }
   
    #endregion

    void OnDestroy()
    {   //unSubbing to same events on destroy 
        GameEvents.current.onPickUpRedCrystal -= PickUpRedCrystal;
        GameEvents.current.onPickUpBlueCrystal -= PickUpBlueCrystal;
    }
} 

