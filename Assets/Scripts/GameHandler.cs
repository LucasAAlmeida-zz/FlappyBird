using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    private int score;
    private int highScore;

    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;

        score = 0;
        highScore = PlayerPrefs.GetInt("highscore");
        GameWindow.Instance.UpdateHighScore(highScore);

        StartCoroutine(CreateObstacles());
    }

    private IEnumerator CreateObstacles()
    {
        yield return new WaitForSeconds(1);
        while(!isGameOver) {
            Obtacle.Create();
            yield return new WaitForSeconds(5);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        AssetHandler.Instance.gameOverWindow.SetActive(true);
        if (score > highScore) {
            PlayerPrefs.SetInt("highscore", score);
            GameWindow.Instance.UpdateHighScore(score);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        GameWindow.Instance.UpdateScore(score);
    }
}
