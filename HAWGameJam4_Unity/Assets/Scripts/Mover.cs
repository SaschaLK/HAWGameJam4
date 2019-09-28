using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] bool _up;

        private bool _stopped;

        private void Update()
        {
            if (_stopped)
                return;
            
            if (_up)
            {
                transform.Translate(Vector3.up * _moveSpeed);
            }
            else
            {
                transform.Translate(Vector3.down * _moveSpeed);
            }
        }

        public void StopMovement()
        {
            _stopped = true;
        }
    }
}