using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageExplosion : MonoBehaviour
{
    LifeLeft life;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("DamageExplosion");
            other.gameObject.GetComponent<LifeLeft>().startLife--;
        }
        
    }
}