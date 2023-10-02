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
   // public event Action onPickUpRedCrystal;
    //public event Action onPickUpBlueCrystal;

    public event Action onPickUpRedKey;
    public event Action onBlueButton;
    public event Action onRedDoor;

    //public event Action ongroundPound;

    #region PickUpCrystals
    /*
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
    } */
    #endregion

    /* public void groundPound()
    {
        if (ongroundPound != null)
        {
            Debug.Log("MEssage RedCrystal recieved");
            ongroundPound();
        }
    }*/

    #region Keys and doors
    public void PickUpRedKey()
    {
        if (onPickUpRedKey != null)
        {
            Debug.Log("MEssage RedKey recieved");
            onPickUpRedKey();
        }
    }

    // when trigger script gets triggered, sends a message here and this sends message to subscribers to start said function
    public void RedDoor()
    {
        if (onRedDoor != null)
        {
            Debug.Log("MEssage RedDoor recieved");
            onRedDoor();
        }
    }

    /* 
    public void BlueButton()
    {
        if (onBlueButton != null)
        {
            Debug.Log("MEssage RedKey recieved");
            onBlueButton();
        }
    }*/
    #endregion
}
