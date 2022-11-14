using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;

    [SerializeField] private float smoothSpeed = 0.15f;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
