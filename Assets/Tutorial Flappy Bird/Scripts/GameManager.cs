using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    internal static GameManager instance;
    public float scrollSpeedMultiply = 1;

    int score = 0;
    internal void AddScore()
    {
        score += 100;
        scoreUI.text = "Score : " + score;
    }

    public GameObject gameOverGo;
    public Text scoreUI;
    internal bool gameover;

    private void Awake()
    {
        instance = this;
    }

    internal void ShowGameOver(bool active)
    {
        if(active)
            gameover = true;
        gameOverGo.SetActive(active);
    }

    private void Update()
    {
        if(gameover)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
