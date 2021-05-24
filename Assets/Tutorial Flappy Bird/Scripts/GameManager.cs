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
    public float scrollSpeedXMultiply = 1;

    public Text scoreUI;
    Text highScoreText;
    int highScore; // 최고 점수 저장. 게임 시작되면 초기화, 게임중 점수 넘기면 ui와 함게 갱신.
    int HighScore
    {
        set
        {
            highScore = value;
            if(highScoreText == null)
                highScoreText = GameObject.Find("Canvas").transform.Find("HighScore").GetComponent<Text>();

            highScoreText.text = $"High Score : {highScore.ToNumber()}";
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    private void Awake()
    {
        instace = this;
        ShowGameOver(false);
        int highScore = PlayerPrefs.GetInt("HighScore");
        HighScore = highScore;  // 속성
        //SetHighScore(highScore); // 함수
    }
    // 함수 버전 사용안함.
    void SetHighScore(int _highScore)
    {
        highScore = _highScore;
        highScoreText.text = $"High Score : {highScore.ToNumber()}";///1
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
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

        if(score > highScore)
        {
            HighScore = score;
            //SetHighScore(score);
        }
    }

}
