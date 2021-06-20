using System;
using System.Collections.Generic;
using Groups.Group_S.Driving.VehicleStats;
using UnityEngine;

namespace Groups.Group_S.Building
{
    public class BuildPartCollector : MonoBehaviour
    {
        public GameObject car;

        private HashSet<VehicleStatProvider> _collected = new HashSet<VehicleStatProvider>();

        private void Start()
        {
            FindObjectOfType<PartKartMiniGame>().OnBuildingFinished += OnBuildingFinished;
        }

        private void OnDestroy()
        {
            FindObjectOfType<PartKartMiniGame>().OnBuildingFinished -= OnBuildingFinished;
        }

        private void OnCollisionEnter(Collision other)
        {
            VehicleStatProvider collidingVehicleStatProvider;
            if (other.gameObject.TryGetComponent(out collidingVehicleStatProvider))
            {
                _collected.Add(collidingVehicleStatProvider);
                Debug.Log("ENTER: " + _collected.Count);
            };
        }

        private void OnCollisionExit(Collision other)
        {
            VehicleStatProvider collidingVehicleStatProvider;
            if (other.gameObject.TryGetComponent(out collidingVehicleStatProvider))
            {
                _collected.Remove(collidingVehicleStatProvider);
                Debug.Log("EXIT: " + _collected.Count);
            }
        }

        private void OnBuildingFinished()
        {
            foreach (var kartPart in _collected)
            {
                Debug.Log("Add KartPart to Car");
                VehicleStatProvider vehicleStatProvider = car.AddComponent<VehicleStatProvider>();
                vehicleStatProvider.vehicleStats = kartPart.vehicleStats;
            }
        }
    }
}
