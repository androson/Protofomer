using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        //this script
        current = this;
    }
    // two events one for each crystal pickup 
    public event Action onPickUpRedCrystal;//Crystal
    public event Action onPickUpBlueCrystal;//Crystal
   
    // when trigger script gets triggered, sends a message here and this sends message to subscribers to start said function
    public void PickUpRedCrystal()
    {
        if(onPickUpRedCrystal != null)
        {
            Debug.Log("MEssage RedCrystal recieved");
            onPickUpRedCrystal();
        }
    }

    // when trigger script gets triggered, sends a message here and this sends message to subscribers to start said function
    public void PickUpBlueCrystal()
    {
        if (onPickUpBlueCrystal != null)
        {
            Debug.Log("MEssage BlueCrystal recieved");
            onPickUpBlueCrystal();
        }
    }

}
