using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class SimpleController_UsingPlayerInput : MonoBehaviour {
    public float moveSpeed;
    public bool usingForce = true;

    private Vector2 m_Move;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        if (!usingForce) {
            rb.useGravity = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        m_Move = context.ReadValue<Vector2>();
    }

    public void Update() {
        if (!usingForce) {
            Move(m_Move);
        }
    }

    private void FixedUpdate() {
        if (usingForce) {
            MoveForce(m_Move);
        }
    }

    private void Move(Vector2 direction) {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, direction.y, 0);
        transform.position += move * scaledMoveSpeed;
    }

    private void MoveForce(Vector2 direction) {
        rb.AddForce(new Vector3(m_Move.x, m_Move.y, 0) * moveSpeed);
    }






    //public void OnLook(InputAction.CallbackContext context)
    //{
    //    m_Look = context.ReadValue<Vector2>();
    //}

    //public void OnFire(InputAction.CallbackContext context)
    //{
    //    switch (context.phase)
    //    {
    //        case InputActionPhase.Performed:
    //            if (context.interaction is SlowTapInteraction)
    //            {
    //                StartCoroutine(BurstFire((int)(context.duration * burstSpeed)));
    //            }
    //            else
    //            {
    //                Fire();
    //            }
    //            m_Charging = false;
    //            break;

    //        case InputActionPhase.Started:
    //            if (context.interaction is SlowTapInteraction)
    //                m_Charging = true;
    //            break;

    //        case InputActionPhase.Canceled:
    //            m_Charging = false;
    //            break;
    //    }
    //}

    //public void OnGUI()
    //{
    //    if (m_Charging)
    //        GUI.Label(new Rect(100, 100, 200, 100), "Charging...");
    //}


    //private void Look(Vector2 rotate)
    //{
    //    if (rotate.sqrMagnitude < 0.01)
    //        return;
    //    var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
    //    m_Rotation.y += rotate.x * scaledRotateSpeed;
    //    m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
    //    transform.localEulerAngles = m_Rotation;
    //}

    //private IEnumerator BurstFire(int burstAmount)
    //{
    //    for (var i = 0; i < burstAmount; ++i)
    //    {
    //        Fire();
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    //private void Fire()
    //{
    //    var transform = this.transform;
    //    var newProjectile = Instantiate(projectile);
    //    newProjectile.transform.position = transform.position + transform.forward * 0.6f;
    //    newProjectile.transform.rotation = transform.rotation;
    //    const int size = 1;
    //    newProjectile.transform.localScale *= size;
    //    newProjectile.GetComponent<Rigidbody>().mass = Mathf.Pow(size, 3);
    //    newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
    //    newProjectile.GetComponent<MeshRenderer>().material.color =
    //        new Color(Random.value, Random.value, Random.value, 1.0f);
    //}
}