using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public int highScore;
    public Text highScoreText;


    [Header("Header Game Over")]
    public GameObject gameOverPanel;
    public Text panelScoreText;

    public void Awake()
    {
        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score:  " + highScore.ToString();

    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score:  " + score;
        }
            panelScoreText.text = "Your Score: "+score.ToString();
         
    }
    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

    }
    public void RestartGame()
    {
        score = 0;
        scoreText.text = "0";

        gameOverPanel.SetActive(false);
        panelScoreText.text = "0";

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        Time.timeScale = 1;
    }
}
