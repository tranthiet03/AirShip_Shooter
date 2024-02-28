using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);
        curScore = 0;
        UpdateUIScore();
        btnStart.onClick.AddListener(() =>
        {
            ActiveGame();
            btnStart.gameObject.SetActive(false);
        });
        btnReStart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        
        isStart = false;
        Time.timeScale = 0;
    }

    public bool isStart = false;
    public void ActiveGame()
    {
        isStart = true;
        Time.timeScale = 1;
    }
    public bool IsStartGame() => isStart;

    [Space(10), Header("SCORE")]
    private int curScore = 0;
    [Space(10), Header("UI")]
    [SerializeField] Text txtCurrentScore, txtHighScore, txtScore;
    [SerializeField] Button btnStart, btnReStart;
    [SerializeField] GameObject gameOverPanel;
    private int HighScore
    {
        get => PlayerPrefs.GetInt("High_Score", 0);
        set
        {
            if (value > PlayerPrefs.GetInt("High_Score", 0))
                PlayerPrefs.SetInt("High_Score", value);
        }
    }
    public void AddScore()
    {
        curScore++;
        UpdateUIScore();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        HighScore = curScore;
        gameOverPanel.SetActive(true);
        txtCurrentScore.text = string.Format($"SCORE: {curScore}");
        txtHighScore.text = string.Format($"HIGH SCORE: {HighScore}");
    }
    void UpdateUIScore()=> txtScore.text = curScore.ToString();
}
