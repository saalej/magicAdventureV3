using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int puntaje = 0;

    public int ScoreInicial
    {
        get
        {
            return puntaje;
        }

        set
        {
            puntaje = value;
        }
    }

    void Start()
    {
        puntaje = 0;
    }

    
}
