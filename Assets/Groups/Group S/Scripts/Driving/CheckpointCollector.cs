using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Groups.Group_S.Driving
{
    public class CheckpointCollector : MonoBehaviour
    {
        private HashSet<MidTrackTrigger> _passedCheckpoints = new HashSet<MidTrackTrigger>();

        public void AddPassedCheckpoint(MidTrackTrigger checkpoint)
        {
            _passedCheckpoints.Add(checkpoint);
        }

        public bool HasPassedAllCheckpoints(int requiredCheckpoints)
        {
            return _passedCheckpoints.Count == requiredCheckpoints;
        }
    }
}
