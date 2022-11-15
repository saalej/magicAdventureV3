using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeLeft : MonoBehaviour
{

    private TMP_Text lifeText;
    private TMP_Text inmunityText;

    [SerializeField] private int startLife = 3;
    [SerializeField] private GameObject player;
    private bool isInmune;
    [SerializeField] private byte counter;

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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" && !isInmune)
        {
            startLife--;
        }
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
    }

    // Update is called once per frame
    void Update()
    {
        if (startLife == 0)
        {
            Destroy(player);
        }
        //Error
        LifeReference.Instance._lifeText.text = startLife + "";
       
    }
}