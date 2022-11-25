using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MoveNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototypeCustom _characterController;

    [SerializeField] private Animator animator;


    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<NetworkCharacterControllerPrototypeCustom>();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }


    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.isGround = _characterController.IsGrounded;

            if (data.isJumpButtonPressed && _characterController.IsGrounded)
            {
                Debug.Log(_characterController.IsGrounded);
                _characterController.Jump();

                animator.SetBool("IsGrounded", false);
                if (data.Direction.y < 0)
                {
                    animator.SetBool("IsFalling", true);
                }

                data.isJumpButtonPressed = false;
            }
            else
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }

            _characterController.Move(data.Direction * Runner.DeltaTime);
            if (data.Direction.x != 0 && _characterController.IsGrounded)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }
        }
        
    }
}
