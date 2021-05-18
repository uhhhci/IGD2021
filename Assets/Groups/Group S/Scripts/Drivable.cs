using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Groups.Group_S
{
    [RequireComponent(typeof(PlayerInput), typeof(CharacterController)), DisallowMultipleComponent]
    public class Drivable : MonoBehaviour
    {
        public float maxForwardSpeed = 50f;
        public float maxBackwardSpeed = 25f;
        public float acceleration = 15f;
        public float gravity = 9.81f;
        public float steeringRate = 2f;

        [SerializeField] private bool inputEnabled = true;
        private CharacterController _controller;
        private Vector3 _speed = Vector3.zero;
        private Vector2 _input = Vector2.zero;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }
        
        private void Start()
        {
            string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
            GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        }

        private void Update()
        {
            var rotationSpeed = Vector3.zero;
            
            if (!_controller.isGrounded)
            {
                _speed.y -= gravity * Time.deltaTime;
            }
            else
            {
                // reset vertical speed to zero
                _speed.y = 0;
                // apply acceleration from input
                _speed.z = Mathf.Clamp(_speed.z + _input.y * acceleration * Time.deltaTime, -maxBackwardSpeed, maxForwardSpeed);
                // apply rotation from input
                rotationSpeed = new Vector3(0, _input.x * steeringRate, 0);
            }

            // move object by accumulated speeds
            _controller.Move(transform.TransformVector(_speed) * Time.deltaTime);
            transform.Rotate(rotationSpeed);
        }

        #region Input Handling

        [UsedImplicitly]
        private void OnMove(InputValue value)
        {
            _input = value.Get<Vector2>();
        }

        [UsedImplicitly]
        private void OnMoveDpad(InputValue value)
        {
            _input = value.Get<Vector2>();
        }

        #endregion
    }
}