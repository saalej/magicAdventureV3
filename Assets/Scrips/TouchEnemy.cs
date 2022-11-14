using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            print("Toque al Slime");
        }
    }
}
