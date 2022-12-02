using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if (hitData.distance < 5 && hitData.transform.tag == "Player")
        {
            animator.SetBool("isAround", true); 
            animator.SetTrigger("diz");
        }
        else if(hitData.distance < 2 && hitData.transform.tag == "Player")
        {
            animator.SetBool("Attack", true);
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
