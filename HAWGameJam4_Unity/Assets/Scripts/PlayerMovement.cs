using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float movementSpeed;
    //public InputAction move;
    private Vector2 moveV;
    //public InputAction action;

    private Rigidbody _rb;

    private float _horizontalMovementValue;
    private float _verticalMovementValue;

    private const string HorizontalTag = "Horizontal";
    private const string VerticalTag = "Vertical";

    void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        //_horizontalMovementValue = Input.GetAxis(HorizontalTag);
        //Debug.Log(Input.GetAxis(HorizontalTag));
        //_verticalMovementValue = Input.GetAxis(VerticalTag);
        //move =
        _horizontalMovementValue = moveV.x;
        _verticalMovementValue = moveV.y;
        MovePlayer();
        //MovePlayer(move.ReadValue<InputAction.CallbackContext>());
        //InputAction.CallbackContext.
        //MovePlayer(InputAction.CallbackContext);

    }

    public void MovePlayer() {
        //Debug.Log(action.ReadValue<Vector2>());
        //Debug.Log(action.)
        //action = InputActionChange.ActionStarted

        _rb.AddForce(new Vector3(_horizontalMovementValue, _verticalMovementValue, 0) * movementSpeed);
        //    Debug.Log(context.ReadValue<Vector2>());
        //InputAction action = InputAction. 

        //Debug.Log(context.ReadValue<Vector2>());
        //Debug.Log(Input.GetAxis(HorizontalTag));
        Debug.Log("hi");

        //    if (Input.GetAxis(HorizontalTag) < 0) {
        //        transform.localEulerAngles = new Vector3(0, 180, 0);
        //    }
        //    if (Input.GetAxis(HorizontalTag) > 0) {
        //        transform.localEulerAngles = new Vector3(0, 0, 0);
        //    }
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveV = context.ReadValue<Vector2>();
        Debug.Log(context.ReadValue<Vector2>());
        //moveV = context.ReadValue<Vector2>();
        //Debug.Log(moveV);
    }

    //public void OnMove() {
    //    moveV 
    //}

    //public void RotatePlayer() {

    //}
}
