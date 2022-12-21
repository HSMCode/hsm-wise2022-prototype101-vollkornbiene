using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    private GameObject _startGameUI;
    private GameObject _playGameUI;
    private GameObject _gameOverUI;

    private bool playingGame = true;

    // variables for items
    private Text itemsUI;
    public string itemsText = "Items";
    public int currentItems;
    public int winItems = 3;
    public int Items;

    // variables for hits
    private Text hitsUI;
    public string hitsText = "Hits";
    public int currentHits;
    public int loseHits = 5;
    public int Hits;

    // variables for result ui
    private Text resultUI;
    public string resultLost = "Du hast verloren";
    public string resultWin = "Du hast gewonnen";

    // variables for game over
    public bool gameOver;
    private bool gameWon;
    private bool gameLost;

    // Start is called before the first frame update
    void Start()
    {
        _startGameUI = GameObject.Find("StartGamePanel");
        _playGameUI = GameObject.Find("PlayGamePanel");
        _gameOverUI = GameObject.Find("GameOverPanel");

        itemsUI = GameObject.Find("Items").GetComponent<Text>();
        hitsUI = GameObject.Find("Hits").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        _startGameUI.SetActive(true);
        _playGameUI.SetActive(false);
        _gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameStart();
    }

    private void CheckGameStart()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _startGameUI.SetActive(false);
            _playGameUI.SetActive(true);

            UpdateItems(Items);
            UpdateHits(Hits);
        }
    }

    public void UpdateItems(int Items)
    {
        currentItems += Items;
        itemsUI.text = itemsText + currentItems.ToString();

        CheckGameOver();
    }

    public void UpdateHits(int Hits)
    {
        currentHits += Hits;
        hitsUI.text = hitsText + currentHits.ToString();

        CheckGameOver();
    }

    private void CheckGameOver()
    {
        // GameOver WIN
        if (currentItems == winItems && currentHits < loseHits)
        {
            gameWon = true;
            gameOver = true;

            resultUI.text = resultWin;
            resultUI.color = Color.green;
        }

        //GameOver LOST
        else if (currentHits >= loseHits)
        {
            gameLost = true;
            gameOver = true;

            resultUI.text = resultLost;
            resultUI.color = Color.red;
        }

        if (gameOver)
        {
            _playGameUI.SetActive(false);
            _gameOverUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                CheckGameStart();
            }
        }
    }
}
