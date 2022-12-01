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
    [SerializeField] private byte counter1;
    [SerializeField] private Animator animator;
    private int money;
    
    [SerializeField] private AudioSource power;
    [SerializeField] private AudioSource coin;
    [SerializeField] private AudioSource bomb;
    [SerializeField] private AudioSource hit;


    // Start is called before the first frame update
    void Start()
    {

        LifeReference.Instance._lifeText.text = startLife + "";
        LifeReference.Instance._inmunityText.text = 0 + "";
    }

    IEnumerator CounterRoutine()
    {
        counter1 = 10;
        while (counter1 >= 0)
        {
            LifeReference.Instance._inmunityText.text = counter1 + "";
            yield return new WaitForSeconds(1);
            counter1--;
            if(counter1 == 0)
            {
                isInmune = false;
                LifeReference.Instance._inmunityText.text = 0 + "";
                yield break;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Health")
        {
            startLife += 3;
            power.Play();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Inmunity")
        {
            isInmune = true;
            power.Play();
            Destroy(other.gameObject);
            StartCoroutine(CounterRoutine());
            StopCoroutine(CounterRoutine());
        }
        else if(other.tag == "EnemyAttack" && !isInmune)
        {
            animator.SetTrigger("Hit");
            hit.Play();
            startLife--;
        }else if(other.tag == "Explosion")
        {
            bomb.Play();
            animator.SetTrigger("Hit");
        }else if(other.tag == "Coin")
        {
            //print(money + "");
            money += 10;
            coin.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startLife == 0)
        {
            //Destroy(player);
        }


        LifeReference.Instance._lifeText.text = startLife + "";
       
    }
}