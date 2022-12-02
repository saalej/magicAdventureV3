using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool attacked;
    //[SerializeField] private int distance;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AttackBox")
        {
            print("player");
            animator.SetTrigger("Hit");
        }
    }

        void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if (hitData.distance < 9 && hitData.transform.tag == "Player")
        {
            animator.SetBool("isAround", true);
            //print("isaround");
            //animator.SetTrigger("diz");
        }
        else
        {
            //animator.SetBool("Attack", false);
            animator.SetBool("isAround", false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireRay();
        
    }
}
