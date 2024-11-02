using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int hiScore;
    private int score;

    // ENCAPSULATION
    public int GetHiScore() {  return hiScore; }

    
    void Awake()
    {
        if (Instance != null)
        {            
            Destroy(gameObject);
            return;
        }
        Instance = this;

        hiScore = PlayerPrefs.GetInt("HISCORE", 0);
    }

    
    public void StartGame()
    {
        score = 0;
        SceneManager.LoadScene(1);
    }

    public void AddPoints(int amount)
    {
        score += amount;
    }


}
