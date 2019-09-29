using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private int value;
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player") {
            int id = other.gameObject.GetComponent<SimpleController_UsingPlayerInput>().id;
            GameManager.instance.UpdatePlayerScore(id, value);
            
            Destroy(gameObject);
        }
        
        Debug.Log("Collsion with consumable");
    }
}
