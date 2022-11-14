using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    //[SerializeField] private float _rotateSpeed = 90;
    [SerializeField] private float _gravity = -10f;
    [SerializeField] private float _jumpSpeed = 5;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject body;

    CharacterController playerController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    private bool flip;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<CharacterController>();
        //transform.Rotate(new Vector3(0, 180, 0));
    }

    // NOTA: SI QUIERES MOVIMIENTO Y ROTACIÓN, SOLO DESCOMENTA LO QUE ESTA DENTRO DE ESTA FUNCIÓN Y LA VARIABLE _rotateSpeed
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        moveVelocity.x = _speed * xInput;
        //print(moveVelocity.x + "");
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
            //moveVelocity = transform.right * _speed * xInput;
            
            //moveVelocity = transform.forward * _speed * yInput;
            //turnVelocity = transform.up * _rotateSpeed * xInput;


            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = _jumpSpeed;
            }
        }

        moveVelocity.y += _gravity * Time.deltaTime;
        playerController.Move(moveVelocity * Time.deltaTime);
        //transform.Rotate(turnVelocity * Time.deltaTime);
    }
}
