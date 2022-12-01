using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionPoint : MonoBehaviour
{
    Score score;
    ScoreReference reference;

    void start()
    {
        score.ScoreInicial = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            score.ScoreInicial += 10;
            ScoreReference.Instance._scoreText.text = score.ScoreInicial.ToString();
            Destroy(gameObject);
        }
    }
}
