using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingManagerBehaviour : MonoBehaviour {
    public static ScrollingManagerBehaviour instance;

    public float wallSpeed;
    public int wallCount;
    public List<GameObject> houseWallsPrefabs;
    private List<GameObject> houseWalls;

    public float ceiling;
    public float floor;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        houseWalls = new List<GameObject>();

        int idCount = 0;
        for(int i = 0; i < wallCount; i++) {
            houseWalls.Add(Instantiate(houseWallsPrefabs[Random.Range(0, houseWallsPrefabs.Count - 1)], new Vector3(0, i, 0), Quaternion.identity));
            houseWalls[idCount].GetComponent<HouseWallBehaviour>().id = idCount;
            if (wallCount * 2 == idCount + 2) {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = 0;
            }
            else {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = idCount + 2;
            }
            idCount++;
            houseWalls.Add(Instantiate(houseWallsPrefabs[Random.Range(0, houseWallsPrefabs.Count - 1)], new Vector3(2, i, 0), Quaternion.identity));
            houseWalls[idCount].GetComponent<HouseWallBehaviour>().id = idCount;
            if(wallCount*2 == idCount + 1) {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = 1;
            }
            else {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = idCount + 2;
            }
            idCount++;
        }
    }

    public void ToggleWalls() {
        foreach(GameObject wall in houseWalls) {
            wall.SetActive(!wall.activeSelf);
        }
    }

    public void ResetWallTile(int id, int idLeader) {
        houseWalls[id].transform.position = new Vector3(houseWalls[id].transform.position.x, houseWalls[idLeader].transform.position.y - 1, houseWalls[id].transform.position.z);
    }
}
