using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaRedCrystal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameEvents.current.PickUpRedCrystal();
            Debug.Log("You in me Red?");
        }
    }
    
}
