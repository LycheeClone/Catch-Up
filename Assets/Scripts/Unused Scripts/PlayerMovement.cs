using System;
using CameraScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerControls
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _playerRb;
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float xSpeed;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float cameraRotationSpeed;
        private Transform _playerTransform;
        private GameObject _target;

        void Start()
        {
            _target = GetComponent<GameObject>();
            _playerTransform = GetComponent<Transform>();
            _playerRb = GetComponent<Rigidbody>();
            cameraTransform = GameObject.FindWithTag("MainCamera").transform;

        }

        private void FixedUpdate()
        {
            ContinuousMovement();
            // if (Input.GetKey(KeyCode.L))
            // {
            //     CameraRotation();
            // }
        }

        private void ContinuousMovement()
        {
            float zAxis = Input.GetAxis("Vertical");
            float xAxis = Input.GetAxis("Horizontal");
            _playerRb.AddForce(xAxis * (xSpeed * Time.deltaTime), 0, zAxis * (forwardSpeed * Time.deltaTime),
                ForceMode.VelocityChange);
        }

        private void CameraRotation()
        {
            float horizontal = Input.GetAxis("Horizontal");

            float angle = cameraRotationSpeed * Time.deltaTime;
            
            cameraTransform.RotateAround(_playerTransform.position, new Vector3(0,90,0),angle);
            //cameraTransform.Rotate(new Vector3(0,90,0),Space.World);
            
            //cameraTransform.RotateAround(_playerTransform.position, new Vector3(0,90,0),90*cameraRotationSpeed);
            
        }
    }
}