using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject lostUI;
    public GameObject winUI;
    public TMP_Text winScoreText, lostScoreText, inGameScoreText;
    private int score;

    void Start()
    {
        score = 0;
    }

    public void EndLevel()
    {
        lostUI.SetActive(true);
        UpdateScoreText(lostScoreText);
        inGameScoreText.gameObject.SetActive(false);
    }

    public void WinLevel()
    {
        winUI.SetActive(true);
        UpdateScoreText(winScoreText);
        inGameScoreText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void AddScore(int achievedScore)
    {
        score += achievedScore;
        UpdateScoreText(inGameScoreText);
    }

    private void UpdateScoreText(TMP_Text text)
    {
        text.text = "Score: " + score;
    }
}