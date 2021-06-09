using System;
using System.Collections.Generic;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    /// <summary>
    /// A MonoBehaviour which provides different vehicle stats for a Drivable GameObject.
    /// Multiple VehicleStatProviders can exist on a single GameObject or its children from where they
    /// will be collected by Drivable.
    /// </summary>
    [Serializable]
    public class VehicleStatProvider : MonoBehaviour
    {
        [SerializeReference]
        public List<VehicleStat> vehicleStats = new List<VehicleStat>();
    }
}