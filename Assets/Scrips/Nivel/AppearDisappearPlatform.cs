using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDisappearPlatform : MonoBehaviour
{
    [SerializeField] private int timeAssign = 5;
    private int timeRandom;
    [SerializeField] private bool isRandom = false;
    [SerializeField] GameObject platform;

    void Start()
    {
        if(isRandom == true)
        {
            timeRandom = Random.Range(2, 5);
            StartCoroutine(RandomAppear());
        } else
        {
            StartCoroutine(AssignAppear());
        }
    }

    IEnumerator RandomAppear()
    {
        bool isActive = false;
        int i = 0;
        while (i < timeRandom)
        {
            if(isActive == true)
            {
                platform.SetActive(false);
                isActive = true;
            } else
            {
                platform.SetActive(true);
                isActive = false;
            }
            yield return new WaitForSeconds(timeRandom);
        }
    }

    IEnumerator AssignAppear()
    {
        bool isActive = false;
        int i = 0;
        Debug.Log("Aun no empiza");
       
        if (isActive == true)
        {
            Debug.Log("Desactivar");
            platform.SetActive(false);
            isActive = false;
        }
        else
        {
            Debug.Log("Activar");
            platform.SetActive(true);
            isActive = true;
        }
        Debug.Log(i);
        i += 1;
        yield return new WaitForSeconds(timeAssign);
        
    }
}
