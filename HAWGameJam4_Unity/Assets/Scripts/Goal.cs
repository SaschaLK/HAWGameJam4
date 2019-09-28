using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool stopped;

    private float timer = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");
        StopScroller();
        
        Debug.Log(timer);
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (stopped)
            return;
        
        transform.Translate(Vector3.up);
    }
    
    private void StopScroller()
    {
        var movingHouseWalls = GameObject.FindGameObjectsWithTag("MovingHouseWall");
        var movingObjects = GameObject.FindGameObjectsWithTag("Moving");

        foreach (var go in movingHouseWalls)
        {
            go.GetComponent<HouseWallBehaviour>().StopMovement();
        }

        foreach (var go in movingObjects)
        {
            go.GetComponent<Mover>().StopMovement();
        }
        
        stopped = true;
    }
}
