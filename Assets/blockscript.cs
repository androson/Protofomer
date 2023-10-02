using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class blockscript : MonoBehaviour
{
    public UnityEvent Hit;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Scarab" || other.gameObject.tag == "Player" && other.contacts[0].normal.y > 0f)
        {
            Hit.Invoke();
        }
    }
}
