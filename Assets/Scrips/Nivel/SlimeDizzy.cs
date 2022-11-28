using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDizzy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private byte counter;

    IEnumerator CounterRoutine()
    {
        print("counter");
        
        while (counter < 3)
        {
            print(counter);
            yield return new WaitForSeconds(1);
            counter++;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //animator.SetTrigger("hit");
            animator.SetBool("Dizzy", true);
            print("DIZZY");
            CounterRoutine();
            animator.SetBool("Dizzy", false);

        }
    }
            
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
