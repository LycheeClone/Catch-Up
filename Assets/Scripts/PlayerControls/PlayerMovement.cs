using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerControls
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _playerRb;
        [SerializeField] private float constSpeedMultiplier;
        [SerializeField] private float xSpeed;


        void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            ContinuousMovement();
        }

        private void ContinuousMovement()
        {
            float zAxis = 1;
            float xAxis = Input.GetAxis("Horizontal");
            _playerRb.AddForce(xAxis*(xSpeed * Time.deltaTime), 0, zAxis * (constSpeedMultiplier * Time.deltaTime));
        }
    }
}