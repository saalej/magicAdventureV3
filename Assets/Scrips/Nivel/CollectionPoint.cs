using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Score>().puntaje += 10;
            ScoreReference.Instance._scoreText.text = other.gameObject.GetComponent<Score>().puntaje.ToString();
            Destroy(gameObject);
        }
    }
}
