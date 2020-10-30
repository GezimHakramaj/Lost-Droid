using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject GameOver;
    public string gameSceneName; 
    void Awake()
    {
        Kill_Player.killPlayer += OnGameOver; 
}
    void OnGameOver()
    {
        GameOver.SetActive(true); 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName); //Loads the game scene again
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    void OnDestroy()
    {
        Kill_Player.killPlayer -= OnGameOver; 
    }
}
