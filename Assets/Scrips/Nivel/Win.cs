using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private AudioSource star;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //win.Play();
            gameObject.SetActive(false);
        }
    }
            // Start is called before the first frame update
    void Start()
    {
        star.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
