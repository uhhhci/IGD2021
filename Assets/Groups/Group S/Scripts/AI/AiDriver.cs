using System;
using System.Collections.Generic;
using Groups.Group_S.Driving;
using UnityEngine;
using UnityEngine.AI;

namespace Groups.Group_S.AI
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Drivable))]
    public class AiDriver : MonoBehaviour
    {
        public Transform[] waypoints;
        [Tooltip("how close the driver has to be to a waypoint to consider it reached")]
        public float waypointThreshold = 1.0f;
        [Tooltip("how far the NavMeshAgents next position should be to the side in order for the driver to start steering")]
        public float steeringThreshold = 0.1f;
        
        private NavMeshAgent _navAgent;
        private Drivable _drivable;
        private Vector2 _currentInput;
        private int _currentWaypointIndex;

        private void Start()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            // disable automatic position updates so that we move the agent via our drive system instead of the agnet
            // setting its position itself
            _navAgent.updatePosition = false;
            _navAgent.updateRotation = false;

            _drivable = GetComponent<Drivable>();

            _currentWaypointIndex = -1;
            NextWaypoint();
        }

        private void Update()
        {
            if (_navAgent.pathPending)
            {
                Debug.Log($"{gameObject.name} still computing its path");
                return;
            }

            if (_navAgent.remainingDistance < waypointThreshold)
            {
                NextWaypoint();
                Debug.Log($"{gameObject.name} has reached a waypoint");
                return;
            }
            
            var target = transform.InverseTransformPoint(_navAgent.nextPosition);

            // compute forward position
            if (target.z > 0)
                _currentInput.y = 1;
            else if (target.z < 0)
                _currentInput.y = -1;
            else
                _currentInput.y = 0;
            
            // compute steering
            if (target.x > steeringThreshold)
                _currentInput.x = 1f;
            else if (target.x < -steeringThreshold)
                _currentInput.x = -1f;
            else
                _currentInput.x = 0;

            _drivable.OnAiMove(_currentInput);
        }

        private void LateUpdate()
        {
            // update the naveAgents position to where we actually moved to and not where it wanted to move
            // this has the effect of the navAgents internal path calculating not drifting from where the car actually
            // is.
            _navAgent.nextPosition = transform.position;
        }

        private void NextWaypoint()
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex < waypoints.Length)
            {
                // set the next waypoint
                _navAgent.destination = waypoints[_currentWaypointIndex].position;
                _currentInput = Vector2.zero;
            }
            else
            {
                // clear destination and input
                _navAgent.isStopped = true;
                _currentInput = Vector2.zero;
                _drivable.OnAiMove(_currentInput);
            }
        }
    }
}