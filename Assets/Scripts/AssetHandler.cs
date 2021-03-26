using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
