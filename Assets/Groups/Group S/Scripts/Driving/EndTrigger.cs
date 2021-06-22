using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Groups.Group_S.Driving
{
    public class EndTrigger : MonoBehaviour
    {
        public int requiredCheckpoints = 2;

        private void OnTriggerEnter(Collider other)
        {
            CheckpointCollector checkpointCollector;
            if (other.gameObject.TryGetComponent(out checkpointCollector))
            {
                if (checkpointCollector.HasPassedAllCheckpoints(requiredCheckpoints))
                {
                    Debug.Log("Car successfully finished!");
                    Drivable drivable;
                    if (other.gameObject.TryGetComponent(out drivable))
                    {
                        FindObjectOfType<PartKartMiniGame>().KartFinishedRace(drivable);
                    }
                }
                else
                {
                    Debug.Log("Not all checkpoints passed!");
                }
            }
        }
    }
}
