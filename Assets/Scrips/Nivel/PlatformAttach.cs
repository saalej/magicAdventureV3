using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlatformAttach : NetworkBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        Time.timeScale = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(GetInput(out NetworkInputData data))
        {
            Debug.Log("Atrapa 1");
            if (other.transform.CompareTag("Player"))
            {
                Debug.Log("Atrapa");
                data.isPlatformMove = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GetInput(out NetworkInputData data))
        {
            if (other.transform.CompareTag("Player"))
            {
                data.isPlatformMove = false;
            }
        }
    }
}
