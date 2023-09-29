using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpOne : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] float jumpSpeed;
    float gravityScale;
    [SerializeField] float gravityMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        gravityScale = playerRB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();
        Debug.Log("gravityScale" + gravityScale);
        Debug.Log("gravityMultiplier" + gravityMultiplier);
        Debug.Log("playerRB.velocity.y" + playerRB.velocity.y);

    }

    private void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRB.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

            if (playerRB.velocity.y > 0)
            {
                playerRB.gravityScale = gravityScale * gravityMultiplier;

            }

            else
            {
                playerRB.gravityScale = gravityScale;
            }
        }
        
       
    }
}
