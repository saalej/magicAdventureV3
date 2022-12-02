using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool attacked;
    private int hits;
    [SerializeField] private GameObject win;
    [SerializeField] private AudioSource die;
    //[SerializeField] private int distance;

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        win.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AttackBox")
        {
            print("player");
            animator.SetTrigger("Hit");
            hits++;
        }
        if(hits >= 3)
        {
            die.Play();
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
        if (hits >= 3)
        {
            animator.Play("Die");
            StartCoroutine(KillOnAnimationEnd());
        }

    }
}
