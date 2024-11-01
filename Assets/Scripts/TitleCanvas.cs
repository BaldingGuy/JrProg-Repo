using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TitleCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText; 


    void Start()
    {
        int hiScore = GameManager.Instance.GetHiScore();
        scoreText.text = $"HiScore: {hiScore}";
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

}
