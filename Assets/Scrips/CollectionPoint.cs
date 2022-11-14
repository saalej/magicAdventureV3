using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionPoint : MonoBehaviour
{
    Score score;
    ScoreReference reference;
    private int puntaje;
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        score = player.GetComponent<Score>();
        if (other.tag == "Player")
        {
            score.puntaje = score.puntaje + 10;
            puntaje = score.puntaje;
            reference._scoreText.text = "Score: " + puntaje.ToString();
            Destroy(gameObject);
        }
    }
}
