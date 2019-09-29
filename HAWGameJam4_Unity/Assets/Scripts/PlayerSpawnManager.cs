using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour {
    public static PlayerSpawnManager instance;
    public List<Vector2> playerSpawnPositions;

    private int playerCount;

    private void Awake() {
        instance = this;
        playerCount = -1;
    }

    public Vector2 SpawnPlayer() {
        playerCount++;
        return playerSpawnPositions[playerCount];
    }
}
