using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    private int score;

    readonly Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
        score = 0;
        StartCoroutine(CreateObstacles());
    }

    private IEnumerator CreateObstacles()
    {
        yield return new WaitForSeconds(1);
        while(true) {
            var gapSize = Random.Range(5, 15);
            var gapPosition = Random.Range(-10, 10);
            var isGapHorizontal = Random.value > 0.5f;
            CreateNewObstacle(gapSize, gapPosition, isGapHorizontal);
            yield return new WaitForSeconds(5);
        }
    }

    public void CreateNewObstacle(int gapSize, int gapPosition, bool isGapHorizontal)
    {
        var obstacle = Instantiate(AssetHandler.Instance.obstaclePrefab);
        var obstacleTransform = obstacle.transform;

        var leftWall = obstacleTransform.GetChild(0);
        var rightWall = obstacleTransform.GetChild(1);

        leftWall.transform.Translate(Vector3.left * gapSize * 0.5f);
        rightWall.transform.Translate(Vector3.right * gapSize * 0.5f);

        if (!isGapHorizontal) {
            obstacleTransform.Rotate(Vector3.forward * 90);
        }

        obstacleTransform.Translate(Vector3.right * gapPosition);

        List<Transform> children = new List<Transform> {
            leftWall.GetChild(0),
            rightWall.GetChild(0)
        };

        var color = colors[Random.Range(0, 4)];
        foreach (var child in children) {
            Renderer r = child.GetComponent<Renderer>();
            r.material.color = color;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        AssetHandler.Instance.gameOverWindow.SetActive(true);
    }

    public bool IsGameOver()
    {
        return isGameOver;
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
        AssetHandler.Instance.ScoreText.text = "Score: " + score;
    }
}
