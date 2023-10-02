using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [SerializeField] public GameObject objects;

   public void spawn()
   {
    Instantiate(objects, transform.position, Quaternion.identity);
   }
}
