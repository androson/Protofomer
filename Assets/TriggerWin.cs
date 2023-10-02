using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    [SerializeField] private GameObject winPop;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip winSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            winPop.SetActive(true);
            audioSource.PlayOneShot(winSound);
            //Time.timeScale = 0;

        }
    }
}
