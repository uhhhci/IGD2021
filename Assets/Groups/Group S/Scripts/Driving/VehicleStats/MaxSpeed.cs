using System;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    [Serializable]
    public class MaxSpeed : VehicleStat
    {
        public float maxForward = 10f;
        public float maxBackward = 3f;
        
        internal override void ModifySpeed(ref Vector3 speed)
        {
            speed.z = Mathf.Clamp(speed.z, -maxBackward, maxForward);
        }
    }
}