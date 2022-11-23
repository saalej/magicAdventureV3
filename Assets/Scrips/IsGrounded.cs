using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    NetworkInputData data = new NetworkInputData();

    private void OnTriggerEnter(Collider other)
    {
        data._isGrounded = false;
        //Debug.Log(data._isGrounded);
    }

    private void OnTriggerExit(Collider other)
    {
        data._isGrounded = true;
        //Debug.Log(data._isGrounded);
    }
}
