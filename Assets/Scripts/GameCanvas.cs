using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] TextMeshProUGUI hiScoreText;
    [SerializeField] Button restartButton;
    [SerializeField] Transform ball;
    private Vector3 ballPosition;

    void Start()
    {
        UpdateHiScoreDisplay();
        ballPosition = ball.position;
    }

    private void Update()
    {
        if (GameManager.Instance.GetIsGameOver())
        {
            UpdateHiScoreDisplay();
            restartButton.gameObject.SetActive(true);
            return;
        }
        restartButton.gameObject.SetActive(false);

        // ABSTRACTION
        UpdateScoreDisplay();
        UpdateTimeDisplay();
    }

    // ABSTRACTION
    private void UpdateScoreDisplay()
    {
        int currentScore = GameManager.Instance.GetScore();
        scoreText.text = $"Points: {currentScore}";
    }

    // ABSTRACTION
    private void UpdateTimeDisplay()
    {
        int currentTime = Mathf.RoundToInt(GameManager.Instance.GetTimer());
        timeDisplay.text = currentTime.ToString("00");
    }

    // ABSTRACTION
    private void UpdateHiScoreDisplay()
    {
        int hiScore = GameManager.Instance.GetHiScore();
        hiScoreText.text = $"HiScore: {hiScore}";
    }


    public void ClickMeButton()
    {
        GameManager.Instance.AddPoints(1);
        StartCoroutine(Shaker());
    }
    
    public void Restart()
    {
        GameManager.Instance.StartGame();
    }

    IEnumerator Shaker()
    {
        float elapsed = 0f;
        float shakeIntensity = 0.03f;
        float shakeDuration = 0.1f;

        while (elapsed < shakeDuration)
        {
            // Generate a random offset for each frame within the intensity range
            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetZ = Random.Range(-shakeIntensity, shakeIntensity);

            // Apply the offset to the object's position
            ball.transform.localPosition = ballPosition + new Vector3(offsetX, offsetY, offsetZ);

            // Increment elapsed time
            elapsed += Time.deltaTime;
            yield return null;
        }

        // After shaking, reset to the original position
        ball.transform.localPosition = ballPosition;
        yield return null;
    }

}
