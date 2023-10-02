using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpSign : MonoBehaviour
{
    private static object setactive;
    public GameObject helpwasd;

    public void Start()
    {
        helpwasd = GetComponent<GameObject>();
        helpSign.setactive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "helpwasd")
        helpSign.setactive= true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "helpwasd")
        helpSign.setactive = false;
    }
}
