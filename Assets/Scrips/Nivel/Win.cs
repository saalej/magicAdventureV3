using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private AudioSource win;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            win.Play();
            print("GANASTE CTM");
            gameObject.SetActive(false);
        }
    }
            // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
