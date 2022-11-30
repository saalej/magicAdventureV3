using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDisappearPlatform : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] private int timeAssign = 5;
    private int timeRandom;
    [SerializeField] private bool isRandom = false;

    [Header("Timeout Setting")]
    [SerializeField] private bool mustWait = false;
    [SerializeField] private int timeAwake = 5;

    [Header("GameObject Setting")]
    [SerializeField] GameObject platform;

    void Start()
    {
        if (mustWait)
        {
            AppearDisappearAwakeState();
        } else
        {
            AppearDisappearState();
        }
    }

    private void AppearDisappearAwakeState()
    {
        if (isRandom)
        {
            timeRandom = Random.Range(2, 5);
            InvokeRepeating("ChangeObjectState", timeAwake, timeRandom);
        }
        else
        {
            InvokeRepeating("ChangeObjectState", timeAwake, timeAssign);
        }
    }

    private void AppearDisappearState()
    {
        if (isRandom)
        {
            timeRandom = Random.Range(2, 5);
            InvokeRepeating("ChangeObjectState", 0f, timeRandom);
        }
        else
        {
            InvokeRepeating("ChangeObjectState", 0f, timeAssign);
        }
    }

    private void ChangeObjectState()
    {
        platform.SetActive(!platform.activeInHierarchy);
    }

   
}
