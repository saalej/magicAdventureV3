using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    //[SerializeField] private float _rotateSpeed = 90;
    [SerializeField] private float _gravity = -10f;
    [SerializeField] private float _jumpSpeed = 5;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject body;

    private bool isJumping;
    private bool isGrounded;

    CharacterController playerController;
    Vector3 moveVelocity;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<CharacterController>();
        //transform.Rotate(new Vector3(0, 180, 0));
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

    }


    // NOTA: SI QUIERES MOVIMIENTO Y ROTACIÓN, SOLO DESCOMENTA LO QUE ESTA DENTRO DE ESTA FUNCIÓN Y LA VARIABLE _rotateSpeed
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        moveVelocity.x = _speed * xInput;
        
        if(moveVelocity.x != 0 && playerController.isGrounded)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (moveVelocity.x < 0)
        {
            body.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if(moveVelocity.x > 0)
        {
            body.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (playerController.isGrounded)
        {
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            //moveVelocity = transform.right * _speed * xInput;

            //moveVelocity = transform.forward * _speed * yInput;
            //turnVelocity = transform.up * _rotateSpeed * xInput;


            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = _jumpSpeed;
                animator.SetBool("IsJumping", true);
            }
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            if(moveVelocity.y < 0)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }

        moveVelocity.y += _gravity * Time.deltaTime;
        playerController.Move(moveVelocity * Time.deltaTime);
        //transform.Rotate(turnVelocity * Time.deltaTime);
    }
}
