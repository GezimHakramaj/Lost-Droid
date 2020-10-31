using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverTimeText;
    public TextMeshProUGUI gameOverBestTimeText;
    public GameObject gameOverMenu;

    int currentTime;
    int bestTime;
    float timer = 0.0f;

    private void Awake()
    {
        Kill_Player.killPlayer += TimeStop;
    }

    void Start()
    {
        currentTime = 0;
        UpdateUI();
        bestTime = PlayerPrefs.GetInt("BestTime", 0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        currentTime = (int)(timer % 60f);
        UpdateUI();
    }

    void UpdateUI()
    {
        timeText.text = currentTime + "";
    }

    void TimeStop()
    {
        enabled = false;
        gameOverMenu.SetActive(true);
        gameOverTimeText.text = timeText.text;
        if(currentTime > bestTime)
        {
            PlayerPrefs.SetInt("BestTime", currentTime);
        }
        gameOverBestTimeText.text = PlayerPrefs.GetInt("BestTime", 0) + "";
    }

    private void OnDestroy()
    {
        Kill_Player.killPlayer -= TimeStop;
    }
}
