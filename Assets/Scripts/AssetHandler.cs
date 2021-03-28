using UnityEngine;
using TMPro;

public class AssetHandler : MonoBehaviour
{
    public static AssetHandler Instance { get; private set; }

    public AssetHandler()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    public GameObject obstaclePrefab;
    public GameObject gameOverWindow;
    public TextMeshProUGUI ScoreText;
}
