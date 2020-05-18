using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;

    public int score;

    public Text scoreText;

    public Text highScore;

    public void Awake()
    {
        highScore.text ="High Score: "+GetHighScore().ToString() ;
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBulding(); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "High Score: " + score.ToString(); 
        }
    }
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }

}
