using UnityEngine;

namespace PlayerControls
{
    public class ThirdPersonPlayerControl : MonoBehaviour
    {
        private Rigidbody _rb;
        private Transform _cam;

        [SerializeField] private float speed = 6f;
        [SerializeField] private float gravity = -9.81f; // the strength of the gravitational force
        [SerializeField] private float turnSmoothTime = 0.1f;
        private float _turnSmoothVelocity;
        private Vector3 _velocity; // the player's current velocity

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _cam = Transform.FindObjectOfType<Camera>().transform;
        }

        void FixedUpdate()
        {
            CharacterControl();
        }

        private void CharacterControl()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _rb.AddForce(moveDir.normalized * (speed * Time.deltaTime), ForceMode.VelocityChange);
            }

            // apply gravity to the player
            _rb.AddForce(new Vector3(0f, gravity, 0f), ForceMode.Acceleration);

            // check if the player is grounded
            if (Physics.Raycast(transform.position, -transform.up, 0.1f))
            {
                // apply additional downward force to keep the player on the ground
                _rb.AddForce(new Vector3(0f, -gravity, 0f), ForceMode.Acceleration);
            }
        }
    }
}