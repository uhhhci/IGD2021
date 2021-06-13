using System;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    [Serializable]
    public class Gravity : VehicleStat
    {
        public float force = 9.81f;

        internal override Vector3 CalcLinearForces(Vector2 playerInput, Vector3 lastSpeed)
        {
            return Vector3.down * force;
        }
    }
}