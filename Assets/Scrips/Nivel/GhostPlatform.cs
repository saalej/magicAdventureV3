using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GhostPlatform : NetworkBehaviour
{

    [SerializeField] private int timeAssign = 5;
    [SerializeField] GameObject platform;

    public override void FixedUpdateNetwork()
    {/*
        if (GetInput(out NetworkInputData data))
        {
            if (data.isGround)
            {
                StartCoroutine(Wait());
                DisableObject();
            } else
            {
                StartCoroutine(Wait());
                ActiveObject();
            }
        }
        }*/
    }

    private void ActiveObject()
    {
        platform.SetActive(true);
    }

    private void DisableObject()
    {
        platform.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeAssign);
    }

}
