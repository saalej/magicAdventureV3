using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MoveNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype _characterController;
    [SerializeField] private int _movementSpeed = 5;
    [SerializeField] private float _gravity = -10f;
    [SerializeField] private float _jumpSpeed = 5;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject body;


    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<NetworkCharacterControllerPrototype>();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            if(_characterController == null)
            {
                Debug.Log("Falta el juegador");
            }

            _characterController.Move(data.Direction * Runner.DeltaTime * _movementSpeed);


            if (data.Direction.x != 0 && _characterController.IsGrounded)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (data.Direction.x < 0)
            {
                body.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (data.Direction.x > 0)
            {
                body.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if (_characterController.IsGrounded)
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);

                if (Input.GetButtonDown("Jump"))
                {
                    data.Direction.y = _jumpSpeed;
                    animator.SetBool("IsJumping", true);
                }
            }
            else
            {
                animator.SetBool("IsGrounded", false);
                if (data.Direction.y < 0)
                {
                    animator.SetBool("IsFalling", true);
                }
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }

            data.Direction.y += _gravity * Time.deltaTime;
            _characterController.Move(data.Direction * Time.deltaTime);
        }
        
    }
}
