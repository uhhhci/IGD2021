using System;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    [Serializable]
    public class Steering : VehicleStat
    {
        public float amount = 1f;
        
        internal override Vector3 CalcRotation(Vector2 playerInput)
        {
            return new Vector3(0, playerInput.x);
        }
    }
}