using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    public event Action onPickUpRedCrystal;//Crystal
    public event Action onPickUpBlueCrystal;//Crystal
    public void PickUpRedCrystal()
    {
        if(onPickUpRedCrystal != null)
        {
            Debug.Log("MEssage RedCrystal recieved");
            onPickUpRedCrystal();
        }
    }

    public void PickUpBlueCrystal()
    {
        if (onPickUpBlueCrystal != null)
        {
            Debug.Log("MEssage BlueCrystal recieved");
            onPickUpBlueCrystal();
        }
    }

}
