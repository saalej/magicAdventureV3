using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text counterUiText;
    [SerializeField] private GameObject player;
    [SerializeField] private byte counter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CounterRoutine());
    }

    IEnumerator CounterRoutine()
    {
        while (counter >= 0)
        {
            counterUiText.text = counter + "";
            yield return new WaitForSeconds(1);
            counter--;
        }
        ResetTheGame();
    }
    void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            ResetTheGame();
        }
        
    }
}
