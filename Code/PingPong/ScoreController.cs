using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ScoreController : MonoBehaviour
{
    private int scorePlayer1;
    private int scorePlayer2;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int scoreToWin;

    // Update is called once per frame
    void Update()
    {
        if(this.scorePlayer1>=this.scoreToWin|| this.scorePlayer2 >= this.scoreToWin)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void FixedUpdate()
    {
        Text uiTextPlyaer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiTextPlyaer1.text = this.scorePlayer1.ToString();

        Text uiTextPlyaer2 = this.scoreTextPlayer2.GetComponent<Text>();
        uiTextPlyaer2.text = this.scorePlayer2.ToString();


    }
    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }
    public void GoalPlayer2()
    {
        this.scorePlayer2++;
    }
}
