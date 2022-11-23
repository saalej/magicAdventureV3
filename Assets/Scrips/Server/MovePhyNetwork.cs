using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovePhyNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype _characterController;

    //[SerializeField] private Animator animator;
    [SerializeField] public int _jumpForce = 15;
    [SerializeField] public Rigidbody _rigidbody;
    [SerializeField] public float _maxVelocity = 20;
    [SerializeField] public NetworkBool _jump = false;
    [SerializeField] private float _movementSpeed = 0.5f;
    //[SerializeField] private GameObject body;


    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<NetworkCharacterControllerPrototype>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }

            if (Input.GetKey(KeyCode.W))
            {
                _jump = true;
            }

            if (_jump)
            {
                Debug.Log(data.Direction);
                _rigidbody.transform.position += (data.Direction * _jumpForce);
                _jump = false;
            }
            
            _rigidbody.transform.position += (data.Direction * _movementSpeed);
            
            
        }

    }
}
