using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    private Rigidbody _rb;
    
    private float _horizontalMovementValue;
    private float _verticalMovementValue;

    private const string HorizontalTag = "Horizontal";
    private const string VerticalTag = "Vertical";

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _horizontalMovementValue = Input.GetAxis(HorizontalTag);
        _verticalMovementValue = Input.GetAxis(VerticalTag);

       MovePlayer();
    }

    private void MovePlayer()
    {
         _rb.AddForce(new Vector3(_horizontalMovementValue, _verticalMovementValue, 0) * movementSpeed);
        
        if (Input.GetAxis(HorizontalTag) < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetAxis(HorizontalTag) > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void RotatePlayer()
    {
        
    }
}
