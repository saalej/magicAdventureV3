using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MoveNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototypeCustom _characterController;

    [SerializeField] private Animator animator;

    LockedOnState lockedOnState;

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
            if (data.Direction.x != 0 && _characterController.IsGrounded)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (_characterController.IsGrounded)
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("IsFalling", false);
                animator.SetBool("IsJumping", false);
                if (data.isJumpButtonPressed)
                {
                    animator.SetBool("IsJumping", true);
                    _characterController.Jump();
                }
            }
            else
            {
                //Debug.Log(data.Direction);
                animator.SetBool("IsGrounded", false);
                /*if (data.Direction.y < 0)
                {
                    animator.SetBool("IsFalling", true);
                    print("toi caiendo");
                }*/
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }

            if (data.isPlatformMove)
            {
                _characterController.Move(data.DirectionPlatform * Runner.DeltaTime);
            } else
            {
                _characterController.Move(data.Direction * Runner.DeltaTime);
            }
            

        }
        
    }
}
