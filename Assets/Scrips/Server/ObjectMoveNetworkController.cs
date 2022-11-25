using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ObjectMoveNetworkController : NetworkBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float cameraSpeed = 10f;


    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.desiredPosition = player.position + offset;

            transform.position = Vector3.Lerp(transform.position, data.desiredPosition, cameraSpeed * Time.deltaTime); 

            transform.LookAt(player);
        }
    }

}
