using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeLeft : MonoBehaviour
{

    [SerializeField] public int startLife = 3;
    [SerializeField] private GameObject player;
    private bool isInmune;
    [SerializeField] private byte counter;
    [SerializeField] private Animator animator;

    private bool damage = false;

    public bool LifeDamage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        LifeReference.Instance._lifeText.text = startLife + "";
    }

    IEnumerator CounterRoutine()
    {
        while (counter < 21)
        {
            LifeReference.Instance._inmunityText.text = counter + "";
            yield return new WaitForSeconds(1);
            counter++;
        }
        isInmune = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Health")
        {
            startLife += 3;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Inmunity")
        {
            print("inmunity");
            isInmune = true;
            Destroy(other.gameObject);
            StartCoroutine(CounterRoutine());
        }
        else if(other.tag == "EnemyAttack" && !isInmune)
        {
            print("attack");
            animator.SetTrigger("Hit");
            startLife--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startLife == 0)
        {
            //Destroy(player);
        }

        if (damage)
        {
            startLife--;
            damage = false;
        }

        LifeReference.Instance._lifeText.text = startLife + "";
       
    }
}