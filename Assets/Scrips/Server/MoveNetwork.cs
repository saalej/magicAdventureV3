using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MoveNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototypeCustom _characterController;

    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jump;
    public bool isAttacking;
    

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
                    jump.Play();
                    _characterController.Jump();
                }
            }
            else
            {
                animator.SetBool("IsGrounded", false);
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }
            
            _characterController.Move(data.Direction * Runner.DeltaTime);
            
            

        }
        
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02Start"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
}
