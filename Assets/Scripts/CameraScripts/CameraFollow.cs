using System;
using PlayerControls;
using UnityEngine;

namespace CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform camera1;
        [SerializeField] private float cameraFollowSpeed = 5f;
        private Vector3 _distanceByPlayer;
    
        void Start()
        {
            //_distanceByPlayer = camera1.position - player.position;
            _distanceByPlayer = CalculateDistance(player);
        }
    
        private void FixedUpdate()
        {
            MoveTheCamera();
        }
    
        private void MoveTheCamera()
        {
            if (player != null)
            {
                var position = player.position;
                var lookAtPlayer = position + _distanceByPlayer;
                camera1.position = Vector3.Lerp(camera1.position, lookAtPlayer, cameraFollowSpeed * Time.deltaTime);
                camera1.LookAt(position);
            }
        }
    
        private Vector3 CalculateDistance(Transform newTarget)
        {
            return transform.position - newTarget.position;
        }
    
    }
} 

