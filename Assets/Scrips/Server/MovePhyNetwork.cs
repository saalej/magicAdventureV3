using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovePhyNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype _characterController;

    [SerializeField] private Animator animator;
    [SerializeField] public int _jumpForce = 15;
    [SerializeField] public Rigidbody _rigidbody;
    [SerializeField] public float _maxVelocity = 20;
    [SerializeField] public NetworkBool _jump = false;
    [SerializeField] private float _movementSpeed = 0.5f;


    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<NetworkCharacterControllerPrototype>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            if (data.Direction.x != 0)
            {
                animator.SetBool("Run", true);
                _rigidbody.transform.position += (data.Direction * _movementSpeed) * Time.deltaTime;
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.W) && data._isGrounded == false)
            {
                Debug.Log("Jump");
                _rigidbody.transform.position += (data.Direction * _jumpForce) * Time.deltaTime;
                animator.SetBool("IsJumping", true);
            }
            /*
            Debug.Log(data._isGrounded);
            if (data._isGrounded)
            {
                Debug.Log("Entro");
                animator.SetBool("IsGrounded", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);

                
            }
            else
            {
                animator.SetBool("IsGrounded", false);
                if (data.Direction.y < 0)
                {
                    animator.SetBool("IsFalling", true);
                }
            }
            */
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }
         
        }

    }
}
