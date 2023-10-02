using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaRedCrystal : MonoBehaviour
{

    // when player touches crystal, sends message to game events script to start the broadcast to subscribers
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameEvents.current.PickUpRedCrystal();
            Debug.Log("You in me Red?");
        }
    }*/

}
