using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    readonly Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };

    private void Awake()
    {
        StartCoroutine(CreateObstacles());
    }

    private IEnumerator CreateObstacles()
    {
        yield return new WaitForSeconds(2);
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
}
