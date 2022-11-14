using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour

{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
