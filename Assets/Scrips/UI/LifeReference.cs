using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeReference : MonoBehaviour
{

    public static LifeReference Instance {
        get;
        private set;
    }

    [SerializeField] public TMP_Text _lifeText;
    [SerializeField] public TMP_Text _inmunityText;

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
