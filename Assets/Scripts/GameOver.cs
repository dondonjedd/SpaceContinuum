using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TMP_Text CurrentScoreText;
    [SerializeField] private TMP_Text HighScoreText;
    public const String HighScoreKey =  "HighScoreKey";





    public void endGame() {
        gameOverCanvas.gameObject.SetActive(true);
        float finalScore = Int16.Parse(scoreText.text);
        CurrentScoreText.text = "Current Score: "+scoreText.text;
        scoreSystem.gameObject.SetActive(false);

        PlayerPrefs.GetInt(HighScoreKey, 0);

        if (finalScore > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(finalScore));
            HighScoreText.text = "High Score: " + Mathf.FloorToInt(finalScore).ToString();
        }
        else {
            HighScoreText.text = "High Score: " + PlayerPrefs.GetInt(HighScoreKey, 0).ToString();
        }

    }

    public void playAgain() {
        SceneManager.LoadScene(1);
    }


    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
