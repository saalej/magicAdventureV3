using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MoveNetwork : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype _characterController;

    [SerializeField] private Animator animator;
    //[SerializeField] private int _jumpForce =2;
    //[SerializeField] private GameObject body;

    
    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<NetworkCharacterControllerPrototype>();
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            float rotationCharacterY = _characterController.transform.eulerAngles.y;

            _characterController.Move(data.Direction * Runner.DeltaTime);
            
            //_characterController.transform.rotation = Quaternion.Euler(0, -90, 0);

            if (data.Direction.x != 0 && _characterController.IsGrounded)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if(_characterController.IsGrounded == false)
            {
                animator.SetBool("IsGrounded", false);
                if (data.Direction.y < 0)
                {
                    animator.SetBool("IsFalling", true);
                }
            } else
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }

            
        }
        
    }
}
