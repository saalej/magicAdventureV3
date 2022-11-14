using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            other.transform.position = new Vector3(0f, 5f, 0f);
            //player.transform.position = new Vector3(0f, 5f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
