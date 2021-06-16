using System;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    [Serializable]
    public class Drag : VehicleStat
    {
        public float amount = 0.5f;
        
        internal override Vector3 CalcLinearForces(Vector2 playerInput, Vector3 lastSpeed)
        {
            return -lastSpeed * amount;
        }
    }
}