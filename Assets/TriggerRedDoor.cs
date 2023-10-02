using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRedDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Destroy(gameObject);
            GameEvents.current.RedDoor();
            Debug.Log("Door!?");
        }
    }
}
