using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpOne : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRB;
 
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private float currentMovementSpeed;

    bool isGrounded;
    [SerializeField] private float jumpApex;
    [SerializeField] private float jumpDuration;

    float timeMovement = 0f;

    //bool crystalRed;
    //bool crystalBlue;

    bool keyRed;
    bool doorRed;
    public GameObject redDoor;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip keyPick;
    [SerializeField] AudioClip doorSound;

    //bool groundBreakable;
    //bool groundSlamming;
    //[SerializeField] private float jumpSpeed;
    //private float gravityScale;
    //[SerializeField] private float gravityMultiplier;

    //[SerializeField] private float runSpeed;

    // Start is called before the first frame update
    void Start()
    {



        //GameEvents.current.onPickUpRedCrystal += PickUpRedCrystal;
        //GameEvents.current.onPickUpBlueCrystal += PickUpBlueCrystal;

        //subscribes to events from event script so they recieve the message
        GameEvents.current.onPickUpRedKey += PickUpRedKey;
        GameEvents.current.onRedDoor += RedDoor;
       
        //GameEvents.current.ongroundPound += groundPound;
    }
    #region Event Subscribtions 

    // set crystalRed true when event broadcast recieved
    /* private void PickUpRedCrystal()
     {
         crystalRed = true;

         Debug.Log("CrystalRed" + crystalRed);
     }
     // set crystalBlue true when event broadcast recieved
     private void PickUpBlueCrystal()
     {
         crystalBlue = true;

         Debug.Log("crystalBlue" + crystalBlue);
     }*/

    // set keyRed true when event broadcast recieved
    private void PickUpRedKey()
     {
         keyRed = true;
        audioSource.PlayOneShot(keyPick);

        Debug.Log("keyRed" + keyRed);
     }

     // set doorRed true when event broadcast recieved and destroy the door 
     private void RedDoor()
     {
         if(keyRed == true)
         {
             doorRed = true;
            audioSource.PlayOneShot(doorSound);
            Destroy(redDoor);
         }


         Debug.Log("doorRed" + doorRed);
     }

     /*
      private void groundPound()
      {
          if(groundSlamming == true)
          {
              Destroy(groundBlock);
          }
          groundBreakable = true;

          Debug.Log("groundBreakable" + groundBreakable);
      }*/
    #endregion


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

        /// Tried making groundslam
       /* if (Input.GetKeyDown(KeyCode.F) && isGrounded == false)
        {
            grav = grav * 6;
            Debug.Log("groundSlamming" + groundSlamming);
            
            groundSlamming = true;
        }
        // when player jumps Velocity.y is positive and when he is descending it goes negative 
        //so when he is descending gravity is doubled to make fall faster 
        else*/ if (playerRB.velocity.y < -0.1)
        {
            grav = grav * 2;
        }
        Debug.Log("grav" + grav);
        float velo = -grav * jumpDuration;

        Physics2D.gravity = new Vector2(0, grav);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            audioSource.PlayOneShot(jumpSound);
            //jump up based on velocity provided by formula 
            playerRB.velocity = Vector2.up * velo;

        }

    }

    #endregion

    #region Ground Check
    
    // simple collision check for if player grounded
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
        //GameEvents.current.onPickUpRedCrystal -= PickUpRedCrystal;
        //GameEvents.current.onPickUpBlueCrystal -= PickUpBlueCrystal;
        GameEvents.current.onPickUpRedKey -= PickUpRedKey;
        GameEvents.current.onRedDoor -= RedDoor;
    }

} 

