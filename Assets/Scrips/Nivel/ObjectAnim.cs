using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnim : MonoBehaviour
{
    [SerializeField] public float amplitude;          //Set in Inspector 
    [SerializeField] public float speed;                  //Set in Inspector 
    [SerializeField] private float tempVal;
    [SerializeField] private Vector3 tempPos;

    void Start()
    {
        tempVal = transform.position.y;
        tempPos = transform.position;
    }

    void Update()
    {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = tempPos;
    }
}
