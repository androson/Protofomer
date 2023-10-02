using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlueButton : MonoBehaviour
{
    [SerializeField] private GameObject blueBridge;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            blueBridge.SetActive(true);
            audioSource.PlayOneShot(buttonSound);
            Destroy(gameObject);
            //GameEvents.current.BlueButton();
            Debug.Log("BlueButton!?");
            
        }
    }
}
