using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorPlayer;
    //[SerializeField] private int distance;

    void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if (hitData.distance < 9 && hitData.distance > 4 && hitData.transform.tag == "Player")
        {
            animator.SetBool("isAround", true);
            print("isaround");
            //animator.SetTrigger("diz");
        }
        else if(hitData.distance <= 4 && hitData.transform.tag == "Player")
        {
            print("attack");
            animator.SetBool("Attack", true);
            animator.SetBool("isAround", false);
        }
        else
        {
            animator.SetBool("Attack", false);
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
