using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private int value;
    
    void OnCollisionEnter(Collision other)
    {
        // Get player number
        int id = 1;
        
        GameManager.instance.UpdatePlayerScore(id, value);
    }
}
