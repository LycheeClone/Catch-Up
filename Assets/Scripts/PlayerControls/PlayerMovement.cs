using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerControls
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _playerRb;
        public Transform playerTransform;
        [SerializeField] private float constSpeedMultiplier;
        [SerializeField] private float xSpeed;

        private void Awake()
        {
            playerTransform = GetComponent<Transform>();
        }

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
            float zAxis = Input.GetAxis("Vertical");
            float xAxis = Input.GetAxis("Horizontal");
            _playerRb.AddForce(xAxis*(xSpeed * Time.deltaTime), 0, zAxis * (constSpeedMultiplier * Time.deltaTime));
        }
    }
}