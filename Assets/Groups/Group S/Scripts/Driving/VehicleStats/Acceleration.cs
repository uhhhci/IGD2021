using System;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    [Serializable]
    public class Acceleration : VehicleStat
    {
        public float amount = 5f;

        internal override Vector3 CalcLinearForces(Vector2 playerInput, Vector3 lastSpeed)
        {
            return Vector3.forward * (playerInput.y * amount);
        }
    }
}