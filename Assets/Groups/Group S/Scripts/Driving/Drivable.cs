using System.Linq;
using Groups.Group_S.Driving.VehicleStats;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Groups.Group_S.Driving
{
    [RequireComponent(typeof(PlayerInput), typeof(CharacterController)), DisallowMultipleComponent]
    public class Drivable : MonoBehaviour
    {
        private CharacterController _controller;
        internal Vector2 Input = Vector2.zero;
        private VehicleStat[] _vehicleStats;
        internal Vector3 LastSpeed;

        private void Start()
        {
            string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
            GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);

            _controller = GetComponent<CharacterController>();
            _vehicleStats = CollectStats();

            LastSpeed = Vector3.zero;
        }

        private void FixedUpdate()
        {
            // accumulate forces from all stats
            var linearForceAcc = new Vector3();
            var rotationAcc = new Vector3();
            foreach (var iStat in _vehicleStats)
            {
                linearForceAcc += iStat.CalcLinearForces(Input, LastSpeed);
                rotationAcc += iStat.CalcRotation(Input);
            }

            // calculate speeds from forces
            var linearSpeed = LastSpeed + linearForceAcc * Time.fixedDeltaTime;
            foreach (var iStat in _vehicleStats)
            {
                iStat.ModifySpeed(ref linearSpeed);
            }

            // apply calculated speed and save it
            var preMovePosition = transform.position;
            _controller.Move(transform.TransformVector(linearSpeed) * Time.fixedDeltaTime);
            LastSpeed = transform.InverseTransformVector((transform.position - preMovePosition) / Time.fixedDeltaTime);
            transform.Rotate(rotationAcc);
        }

        internal VehicleStat[] CollectStats()
        {
            return GetComponentsInChildren<VehicleStatProvider>()
                .SelectMany(provider => provider.vehicleStats)
                .ToArray();
        }

        #region Input Handling

        [UsedImplicitly]
        private void OnMove(InputValue value)
        {
            Input = value.Get<Vector2>();
        }

        [UsedImplicitly]
        private void OnMoveDpad(InputValue value)
        {
            Input = value.Get<Vector2>();
        }

        #endregion
    }
}