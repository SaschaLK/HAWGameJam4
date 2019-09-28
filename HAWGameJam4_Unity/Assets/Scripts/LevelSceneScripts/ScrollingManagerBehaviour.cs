using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingManagerBehaviour : MonoBehaviour 
{
    public static ScrollingManagerBehaviour instance;
    
    public float wallSpeed;
    public float ceiling;
    
    [SerializeField] float floor;
    [SerializeField] int wallCount;
    [SerializeField] float scaleVector;
    [SerializeField] List<GameObject> houseWallsPrefabs;
    
    private List<GameObject> houseWalls;
    
    private void Awake() {
        instance = this;
    }

    private void Start() {
        houseWalls = new List<GameObject>();

        int idCount = 0;
        
        for(int i = 0; i < wallCount; i++) 
        {
            houseWalls.Add(Instantiate(houseWallsPrefabs[Random.Range(0, houseWallsPrefabs.Count - 1)],
                new Vector3(-1*scaleVector, i * scaleVector, 0), Quaternion.identity));
            houseWalls[idCount].GetComponent<HouseWallBehaviour>().id = idCount;
            
            if (wallCount * 2 == idCount + 2) 
            {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = 0;
            }
            else 
            {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = idCount + 2;
            }
            
            idCount++;
            
            houseWalls.Add(Instantiate(houseWallsPrefabs[Random.Range(0, houseWallsPrefabs.Count - 1)],
                new Vector3(1*scaleVector, i * scaleVector, 0), Quaternion.identity));
            houseWalls[idCount].GetComponent<HouseWallBehaviour>().id = idCount;
            
            if(wallCount*2 == idCount + 1) 
            {
                houseWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = 1;
            }
            else 
            {
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
        houseWalls[id].transform.position = new Vector3(houseWalls[id].transform.position.x, houseWalls[idLeader].transform.position.y - scaleVector, houseWalls[id].transform.position.z);
    }
}
