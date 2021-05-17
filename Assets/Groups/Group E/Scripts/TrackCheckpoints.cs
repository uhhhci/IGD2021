using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackCheckpoints : MonoBehaviour
{
    private List<TriggerZone> triggerZones;
    private List<int> nextCheckpointSingleIndexList;
    public List<Transform> carTransformList;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        triggerZones = new List<TriggerZone>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            TriggerZone triggerZone = checkpointSingleTransform.GetComponent<TriggerZone>();
            triggerZone.SetTrackCheckPoints(this);
            triggerZones.Add(triggerZone);
        }

        nextCheckpointSingleIndexList = new List<int>();
        foreach(Transform carTransform in carTransformList)
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }

    public void CarThroughCheckpoint(TriggerZone triggerZone, Transform carTransform)
    {
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)];
        if (triggerZones.IndexOf(triggerZone) == nextCheckpointSingleIndex)
        {
            Debug.Log("Correct");
            nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)] = (nextCheckpointSingleIndex + 1) % triggerZones.Count;
        } else
        {
            Debug.Log("Wrong");
        }
    }
}
