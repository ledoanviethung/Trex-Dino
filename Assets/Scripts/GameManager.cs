using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float originalSpeed = 5f;
    public float speedBost = 0.1f;
    public float gameSpeed;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public TextMeshProUGUI gameOverText;
    public Button btnReset;

    private Player player;
    private Spawner spawner;

    private float score;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();

        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = originalSpeed;
        enabled = true;

        player.gameObject.SetActive(true);

        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        btnReset.gameObject.SetActive(false);

        UpdateHighscore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);

        btnReset.gameObject.SetActive(true);

        UpdateHighscore();
    }

    private void Update()
    {
        
        gameSpeed += speedBost * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("00000");
    }

    private void UpdateHighscore()
    {

        float highscore = PlayerPrefs.GetFloat("highscore", 0);

        if (score > highscore)
        {


            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
        }

        highscoreText.text = Mathf.FloorToInt(highscore).ToString("0000");
    }
}
