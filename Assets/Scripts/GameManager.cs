using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] int hiScore;
    private int score;
    private bool isGameOver;
    private float timer;

    // ENCAPSULATION
    public int GetHiScore() {  return hiScore; }
    public int GetScore() { return score; }
    public bool GetIsGameOver() { return isGameOver; } 
    public float GetTimer() { return timer; }

    
    void Awake()
    {
        if (Instance != null)
        {            
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        hiScore = PlayerPrefs.GetInt("HISCORE", 0);
    }

    private void Start()
    {
        InitiateValues();        
    }


    private void Update()
    {
        if (isGameOver) return;

        timer -= Time.deltaTime;
        if (timer < 0) GameOver();
    }
            
    private void InitiateValues()
    {
        isGameOver = false;
        timer = 60;
        score = 0;
    }

    private void GameOver()
    {
        isGameOver = true;

        // ABSTRACTION
        CheckHiScore();
    }

    private void CheckHiScore()
    {
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt("HISCORE", hiScore);
            PlayerPrefs.Save();
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
        InitiateValues();
    }

    // ABSTRACTION
    public void AddPoints(int amount)
    {
        score += amount;
    }

    // ABSTRACTION
    public void DeductPoints(int amount)
    {
        score -= amount;
    }


}
