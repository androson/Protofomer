using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRedKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameEvents.current.PickUpRedKey();
            Debug.Log("KEY!?");
        }
    }
}
