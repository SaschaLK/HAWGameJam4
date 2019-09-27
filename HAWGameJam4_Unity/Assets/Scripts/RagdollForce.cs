using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollForce : MonoBehaviour
{
    private int counter;

    private float randomValueOne = -0.00005f;
    private float randomValueTwo = 0.00005f;
    
    void Update()
    {
        counter++;

        if (counter == 10)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(randomValueOne,randomValueTwo),Random.Range(randomValueOne,randomValueTwo), 0));
            
            counter = 0;
        }
    }
}
