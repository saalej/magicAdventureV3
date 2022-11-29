using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovePlatform : NetworkBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    [SerializeField] private float _speed = 4;

    public override void FixedUpdateNetwork()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, _speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        
        if (distance <= 0.1f)
        {
            if (targetIndex >= waypoints.Count - 1)
            {
                targetIndex = 0;
            }
            else
            {
                targetIndex++;
            }
        }

        if (GetInput(out NetworkInputData data))
        {
            data.DirectionPlatform += transform.position;
            Debug.Log(data.DirectionPlatform);
        }
    }
}
