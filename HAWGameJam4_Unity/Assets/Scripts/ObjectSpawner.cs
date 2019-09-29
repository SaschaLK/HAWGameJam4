using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToSpawn;

    private float _counter;
    private float _instantiationCounter;

    void Update()
    {
        if (GameManager.instance.currentGameState != GameManager.GameStates.RUNNING)
            return;
        
        _counter += Time.deltaTime;

        if (_counter >= 5 && _counter <= 30)
        {
            _instantiationCounter += Time.deltaTime;

            if (_instantiationCounter >= 5)
            {
                GameObject cons = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], new Vector3(Random.Range(-6, 6), transform.position.y, 0),
                    Quaternion.identity);

                cons.GetComponent<Mover>().StartMovement();
                
                _instantiationCounter = 0;
            }
        }
    }
}
