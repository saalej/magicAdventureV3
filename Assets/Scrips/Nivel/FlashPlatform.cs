using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Material materialOriginal;
    private bool isPlayerEnter = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BlinkingPlatform());
            isPlayerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }

    IEnumerator BlinkingPlatform()
    {
        while (true)
        {
            platform.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            platform.GetComponent<Renderer>().material = materialOriginal;
            yield return new WaitForSeconds(0.5f);
            if (isPlayerEnter == false)
            {
                yield break;
            }
        }

    }
}
