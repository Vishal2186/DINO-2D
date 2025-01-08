using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Unity.Mathematics;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }
    private float Score;
    private float HIGHscore;
    public Text gameover;
    public Text scoretext;
    public Text HIscoretext;
    public Button Restartbutton;
    private Player player;
    private Spawner spawner;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy()
    {
        if(Instance == this)
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
        Opstical[] opsticals = FindObjectsOfType<Opstical>();
        Score = 0f;
        foreach (var Opstical in opsticals)
        {
            Destroy(Opstical.gameObject);
        }
        gameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameover.gameObject.SetActive(false);
        Restartbutton.gameObject.SetActive(false);
        UpdateHIscore();
    }
    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameover.gameObject.SetActive(true);
        Restartbutton.gameObject.SetActive(true);
        UpdateHIscore();
    }
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        Score += gameSpeed * Time.deltaTime;
        scoretext.text = Mathf.RoundToInt(Score).ToString("D5");
    }
    private void UpdateHIscore()
    {
        float HIGHscore = PlayerPrefs.GetFloat("highscore" , 0 );
        if(Score > HIGHscore)
        {
            HIGHscore = Score;
            PlayerPrefs.SetFloat("highscore" , HIGHscore);
        }
        HIscoretext.text = Mathf.RoundToInt(HIGHscore).ToString("D5");
    }
}
