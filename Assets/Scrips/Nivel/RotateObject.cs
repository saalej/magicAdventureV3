using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed = 5;

    private void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }
}
