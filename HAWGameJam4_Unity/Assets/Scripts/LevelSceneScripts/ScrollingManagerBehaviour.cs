using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingManagerBehaviour : MonoBehaviour 
{
    public static ScrollingManagerBehaviour instance;
    
    [Header("General")]
    [SerializeField] float scaleVector;
    
    [Header("OuterWalls")]
    
    public float outerWallSpeed;
    public float ceiling;
    [SerializeField] int outerWallCount;
    [SerializeField] List<GameObject> outerWallPrefabs;
    
    private List<GameObject> outerWalls;
    
    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        InstantiateOuterWalls();
    }

    public void ToggleWalls() 
    {
        foreach(GameObject wall in outerWalls) {
            wall.SetActive(!wall.activeSelf);
        }
    }

    public void ResetWallTile(int id, int idLeader) {
        outerWalls[id].transform.position = new Vector3(outerWalls[id].transform.position.x, outerWalls[idLeader].transform.position.y - scaleVector, outerWalls[id].transform.position.z);
    }

    private void InstantiateOuterWalls()
    {
        outerWalls = new List<GameObject>();

        int idCount = 0;
        
        for(int i = 0; i < outerWallCount; i++) 
        {
            outerWalls.Add(Instantiate(outerWallPrefabs[Random.Range(0, outerWallPrefabs.Count - 1)],
                new Vector3(-1 * scaleVector - 4, i * scaleVector - 10, 3f), Quaternion.identity));
            outerWalls[idCount].GetComponent<HouseWallBehaviour>().id = idCount;
            
            if (outerWallCount * 2 == idCount + 2) 
            {
                outerWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = 0;
            }
            else 
            {
                outerWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = idCount + 2;
            }
            
            idCount++;
            
            outerWalls.Add(Instantiate(outerWallPrefabs[Random.Range(0, outerWallPrefabs.Count - 1)],
                new Vector3(1 * scaleVector + 4, i * scaleVector - 10, 3f), Quaternion.identity));
            outerWalls[idCount].GetComponent<HouseWallBehaviour>().id = idCount;
            
            if(outerWallCount*2 == idCount + 1) 
            {
                outerWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = 1;
            }
            else 
            {
                outerWalls[idCount].GetComponent<HouseWallBehaviour>().idLeader = idCount + 2;
            }
            idCount++;
        }
    }
}
