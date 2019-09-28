using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToSpawn;

    private float _counter;
    private float _instantiationCounter;

    void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= 5 && _counter <= 30)
        {
            _instantiationCounter += Time.deltaTime;

            if (_instantiationCounter >= 5)
            {
                Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], new Vector3(Random.Range(-6, 6), 0, 0),
                    Quaternion.identity);
                
                _instantiationCounter = 0;
            }
        }
    }
}
