using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour {
    public static PlayerSpawnManager instance;
    public List<Vector2> playerSpawnPositions;

    public int playerCount;

    private void Awake() {
        instance = this;
        playerCount = -1;
    }

    public Vector2 SpawnPlayer() {
        playerCount++;
        CameraScope.instance.targets[playerCount] = gameObject.transform;
        GameManager.instance.PlayerConnected();
        return playerSpawnPositions[playerCount];
    }
}
