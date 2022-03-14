using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text HighScoreText;
    

    private void Start()
    {
        HighScoreText.text = "High Score: "+PlayerPrefs.GetInt(GameOver.HighScoreKey, 0).ToString();
    }
    public void startGame() {
        SceneManager.LoadScene(1);
    }
}
