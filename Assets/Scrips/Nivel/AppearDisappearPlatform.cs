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
            InvokeRepeating("ChangeObjectState", 0f, timeRandom);
        } else
        {
            InvokeRepeating("ChangeObjectState", 0f, timeAssign);
        }
    }

    private void ChangeObjectState()
    {
        platform.SetActive(!platform.activeInHierarchy);
    }

   
}
