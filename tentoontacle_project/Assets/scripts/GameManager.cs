using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // Tentacle Variable's
    public Transform[] spawnLocations;
    public GameObject myTentacle;
    private float spawnTimer;
    private float spawnCooldown = 1f;
    public GameObject spawnMyTentacle;

    // score Variable's
    private int randomSpawnNumber;
    private int score;
    private int highscore;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScoreText;
    [SerializeField] private GameObject gameOverHighscoreText;
    
    // timer variable's
    [SerializeField] private Text timerText;
    private float startTimer = 30;
    private float _currentTimer;
    
    // game over menu variable's
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject wackATable;
    private bool isGameOver;
    public int Score
    {
        get { return score; }
        set { score = value; }

    }

    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    public ObjectPool Pool { get; set; }

    private void Awake()
    {
        myTentacle = (GameObject) AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Tentacle.prefab");
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentTimer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTimer >= 0)
        {
            _currentTimer -= 1 * Time.deltaTime;
            timerText.text = "Timer: " + _currentTimer.ToString("0");
            if (spawnTimer >= spawnCooldown)
            {SpawnTentacle();}
        }
        else
        {
            GameOver();
        }
        scoreText.text = String.Format("Score: <color=lime>{0}</color>", score);
        spawnTimer += Time.deltaTime;
        
    }
    
    
    public void SpawnTentacle()
    {
            randomSpawnNumber = Random.Range(0, 9);
            spawnMyTentacle = Instantiate(myTentacle, spawnLocations[randomSpawnNumber].transform.position, Quaternion.Euler(-45,0,0));
            spawnTimer = 0;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            gameOverScoreText.GetComponent<TextMesh>().text =  String.Format("Score: <color=lime>{0}</color>", score);
            highscore = PlayerPrefs.GetInt("highscore");
            if (score >= highscore)
            {
                PlayerPrefs.SetInt("highscore", score);
                PlayerPrefs.Save();
            }
            gameOverHighscoreText.GetComponent<TextMesh>().text = string.Format("Highscore: <color=gold>{0}</color>", highscore);
            isGameOver = true;
            gameOverMenu.SetActive(true);
            wackATable.SetActive(false);
        }
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
