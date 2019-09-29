using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.Animations;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool _stopped = true;
    private float _timer = 0;

    private void OnCollisionEnter(Collision other)
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<GameManager>().EndGame();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.PlayerConnected();
        }
        
        if (_stopped)
            return;
        
        transform.Translate(Vector3.up);
    }

    public void StopMovement()
    {
        _stopped = true;
    }

    public void StartMovement()
    {
        _stopped = false;
    }
}
