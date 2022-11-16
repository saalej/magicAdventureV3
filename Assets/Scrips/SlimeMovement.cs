using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 finalPos;
    [SerializeField] private int distance;
    [SerializeField] private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        finalPos = initialPos - new Vector3(distance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= initialPos.x + 0.5 || transform.position.x <= finalPos.x)
            transform.Rotate(0f, 180f, 0f, Space.Self);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
    }
}
