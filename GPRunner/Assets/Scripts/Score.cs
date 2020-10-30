using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance; //Our singleton
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Cscore;
    public TextMeshProUGUI Hscore;
    public int scorepc;
    public bool increaseScore;
    float score;
    float highScore;



    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; //Then we set our singleton to this instance
        }
        Kill_Player.killPlayer += OnDeath;
    }

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetFloat("HighScore", 0); //Loads thehighscore from the saved key of "HighScore" into our highScore variable
        UpdateUI();
    }

    void Update()
    {
        if (increaseScore)
        {
            score += scorepc * Time.deltaTime;
        }
        UpdateUI();
    }

    public float HighScore
    {
        get
        {
            return highScore;
        }
    }
    public float SScore
    {
        get
        {
            return score;
        }
    }
    void UpdateUI()
    {
        scoreText.text = Mathf.Round(score) + "";
    }
    void OnDeath()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        Cscore.text = "score: " + Mathf.Round(score) + " ";
        Hscore.text = "highest score: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0)) + " ";
    }
    void OnDestory()
    {
        Kill_Player.killPlayer -= OnDeath;
    }
}
