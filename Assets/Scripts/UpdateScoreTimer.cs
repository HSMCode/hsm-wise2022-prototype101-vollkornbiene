using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScoreTimer : MonoBehaviour
{
    private GameObject _gameUI;
    private GameObject _gameOverUI;

    // variables for score
    private Text scoreUI;
    public string scoreText = "Punktestand";
    public int score;
    private int currentScore = 0;

    public int winScore = 2;

    // variables for timer
    private Text timerUI;
    public string timerText = "Countdown";
    public float countRemaining = 30f;
    private bool countingDown = true;

    // variables for result ui
    private Text resultUI;
    public string resultLost = "Verloren";
    public string resultWin = "Gewonnen";

    // variables for game over
    public bool gameOver;
    private bool gameWon;
    private bool gameLost;


    // Start is called before the first frame update
    void Start()
    {
        _gameUI = GameObject.Find("GamePanel");
        _gameOverUI = GameObject.Find("GameOverPanel");

        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        UpdateScore(score);

        if (gameOver && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(4);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentScore += addScore;
        //    scoreUI.text = scoreText + currentScore.ToString();
        //}
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreUI.text = scoreText + currentScore.ToString();
    }

    private void CountdownTimer()
    {
        if(countingDown)
        {
            if(countRemaining > 0)
            {
                countRemaining -= Time.deltaTime;
                timerUI.text = timerText + Mathf.Round(countRemaining).ToString();
            }

            else
            {
                countRemaining = 0;
                timerUI.text = timerText + countRemaining.ToString();
                countingDown = false;

                CheckGameOver();
            }
        }
    }

    private void CheckGameOver()
    {
        // GameOver WIN
        if(currentScore >= winScore)
        {
            gameWon = true;
            gameOver = true;

            StartCoroutine(GameOver());
        }

        //GameOver LOST
        else if(currentScore < winScore && !countingDown)
        {
            gameLost = true;
            gameOver = true;

            StartCoroutine(GameOver());

        }

        //if (gameOver)
        //{
        //    _gameUI.SetActive(false);
        //    _gameOverUI.SetActive(true);
        //}
    }

    //game over
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);

        if (gameWon)
        {
            resultUI.text = resultWin;
            resultUI.color = Color.green;
        }

        if (gameLost)
        {
            resultUI.text = resultLost;
            resultUI.color = Color.red;
        }

        _gameUI.SetActive(false);
        _gameOverUI.SetActive(true);
    }
}
