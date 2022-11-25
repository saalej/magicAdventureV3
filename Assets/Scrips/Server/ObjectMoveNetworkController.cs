using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ObjectMoveNetworkController : NetworkBehaviour
{
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            transform.position += data.Direction;

        }
    }

    /*
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

    }
    */
}
