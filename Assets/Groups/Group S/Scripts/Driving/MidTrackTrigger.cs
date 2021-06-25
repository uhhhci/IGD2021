using System;
using System.Collections;
using System.Collections.Generic;
using Groups.Group_S.Driving.VehicleStats;
using UnityEngine;

namespace Groups.Group_S.Driving
{
    public class MidTrackTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            CheckpointCollector checkpointCollector;
            if (other.gameObject.TryGetComponent(out checkpointCollector))
            {
                checkpointCollector.AddPassedCheckpoint(this);
            }
        }
    }

}
