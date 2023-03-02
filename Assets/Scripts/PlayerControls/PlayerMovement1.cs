using System;
using CameraScripts;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace PlayerControls
{
    // public class PlayerMovement : MonoBehaviour
    // {
    //     private Rigidbody _playerRb;
    //     [SerializeField] private float forwardSpeed;
    //     [SerializeField] private float xSpeed;
    //     [SerializeField] private Transform cameraTransform;
    //     [SerializeField] private float cameraRotationSpeed;
    //     private Transform _playerTransform;
    //     private GameObject _target;
    //
    //     void Start()
    //     {
    //         _target = GetComponent<GameObject>();
    //         _playerTransform = GetComponent<Transform>();
    //         _playerRb = GetComponent<Rigidbody>();
    //         cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    //
    //     }
    //
    //     private void FixedUpdate()
    //     {
    //         ContinuousMovement();
    //         // if (Input.GetKey(KeyCode.L))
    //         // {
    //         //     CameraRotation();
    //         // }
    //     }
    //
    //     private void ContinuousMovement()
    //     {
    //         float zAxis = Input.GetAxis("Vertical");
    //         float xAxis = Input.GetAxis("Horizontal");
    //         _playerRb.AddForce(xAxis * (xSpeed * Time.deltaTime), 0, zAxis * (forwardSpeed * Time.deltaTime),
    //             ForceMode.VelocityChange);
    //     }
    //
    //     private void CameraRotation()
    //     {
    //         float horizontal = Input.GetAxis("Horizontal");
    //
    //         float angle = cameraRotationSpeed * Time.deltaTime;
    //         
    //         cameraTransform.RotateAround(_playerTransform.position, new Vector3(0,90,0),angle);
    //         //cameraTransform.Rotate(new Vector3(0,90,0),Space.World);
    //         
    //         //cameraTransform.RotateAround(_playerTransform.position, new Vector3(0,90,0),90*cameraRotationSpeed);
    //         
    //     }
    // }
    public class PlayerMovement1 : MonoBehaviour
    {
//         public CharacterController controller; 
//         public Transform cam;
//
//         public float speed = 6f;
//
//         public float turnSmoothTime = 0.1f;
//         float turnSmoothVelocity;
//
// // Update is called once per frame
//         void Update()
//         {
//             float horizontal = Input.GetAxisRaw("Horizontal");
//             float vertical = Input.GetAxisRaw("Vertical");
//             Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
//             if (direction.magnitude >= 0.1f)
//             {
//                 float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
//                 float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);
//                 transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
//                 Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//                 controller.Move(moveDir.normalized * (speed * Time.deltaTime));
//             }
//         }
//************************************************************************************************************
        // public CharacterController controller; 
        // public Transform cam;
        //
        // public float speed = 6f;
        // public float gravity = -9.81f; // the strength of the gravitational force
        //
        // public float turnSmoothTime = 0.1f;
        // float turnSmoothVelocity;
        // Vector3 velocity; // the player's current velocity
        //
        // void Update()
        // {
        //     float horizontal = Input.GetAxisRaw("Horizontal");
        //     float vertical = Input.GetAxisRaw("Vertical");
        //     Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //
        //     if (direction.magnitude >= 0.1f)
        //     {
        //         float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
        //             turnSmoothTime);
        //         transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        //         Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //         controller.Move(moveDir.normalized * (speed * Time.deltaTime));
        //     }
        //
        //     // apply gravity to the player
        //     velocity.y += gravity * Time.deltaTime;
        //     controller.Move(velocity * Time.deltaTime);
        //**************
        public Rigidbody rb;
        public Transform cam;

        public float speed = 6f;
        public float gravity = -9.81f; // the strength of the gravitational force

        public float turnSmoothTime = 0.1f;
        float turnSmoothVelocity;
        Vector3 velocity; // the player's current velocity

        void FixedUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                rb.AddForce(moveDir.normalized * (speed * Time.deltaTime), ForceMode.VelocityChange);
            }

            // apply gravity to the player
            rb.AddForce(new Vector3(0f, gravity, 0f), ForceMode.Acceleration);

            // check if the player is grounded
            if (Physics.Raycast(transform.position, -transform.up, 0.1f))
            {
                // apply additional downward force to keep the player on the ground
                rb.AddForce(new Vector3(0f, -gravity, 0f), ForceMode.Acceleration);
            }
        }
    }
}
