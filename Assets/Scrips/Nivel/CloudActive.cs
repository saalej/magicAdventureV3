using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudActive : MonoBehaviour
{

    [SerializeField] private GameObject clouds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clouds.SetActive(false);
        }
    }
}
