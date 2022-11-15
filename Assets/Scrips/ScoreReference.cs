using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreReference : MonoBehaviour
{
    public static ScoreReference Instance
    {
        get;
        private set;
    }

    [SerializeField] public TMP_Text _scoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
