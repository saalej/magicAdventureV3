using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 finalPos;
    [SerializeField] private int distance;
    [SerializeField] private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        finalPos = initialPos - new Vector3(distance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(initialPos, finalPos, Mathf.PingPong(Time.time * speed, 1.0f));
        transform.position += transform.forward * Time.deltaTime * speed;
        if (transform.position.x <= finalPos.x)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (transform.position.x >= initialPos.x)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }
}
