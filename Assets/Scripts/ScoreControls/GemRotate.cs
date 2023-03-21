using System;
using UnityEngine;

namespace GemControls
{
    public class GemRotate : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed;

        private void FixedUpdate()
        {
            Rotater();
        }

        private void Rotater()
        {
            transform.Rotate(new Vector3(0f,rotateSpeed,0f),Space.Self);
            

        }
    }
}
