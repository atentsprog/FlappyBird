using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// 기둥 통과할때마다 점수 100점식 올리자
/// 새가 죽으면 게임 종료 UI표시하자.
/// </summary>
public class GameManager : MonoBehaviour
{
    static public GameManager instace;

    public GameObject gameOverUI;
    public Text scoreUI;
    public float scrollSpeedXMultiply = 1;

    private void Awake()
    {
        instace = this;
        ShowGameOver(false);
    }

    bool isGameOver;// = false;// ?
    internal void SetGameOver()
    {
        isGameOver = true;
        ShowGameOver(true);
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //게임 재시작.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    internal void ShowGameOver(bool active)
    {
        gameOverUI.SetActive(active);
    }

    int score;

    internal void AddScore()
    {
        score += 100;
        scoreUI.text = "Score : " + score;
    }

}
