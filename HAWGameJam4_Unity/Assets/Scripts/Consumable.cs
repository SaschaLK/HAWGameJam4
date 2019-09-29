using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private int value;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            int id = other.gameObject.GetComponent<SimpleController_UsingPlayerInput>().id;
            GameManager.instance.UpdatePlayerScore(id, value);
            
            Destroy(gameObject);
        }
        
        Debug.Log("Collsion with consumable");
    }
}
