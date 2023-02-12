using System;
using PlayerControls;
using UnityEngine;

namespace CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {

        private Transform _target;


        private void Start()
        {
            _target = FindObjectOfType<PlayerMovement>().playerTransform;
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            gameObject.transform.LookAt(_target);
        }
    }
}