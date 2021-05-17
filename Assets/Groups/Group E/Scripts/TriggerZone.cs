using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    void OnTriggerEnter(Collider collision)
    {
        // Test for player
        Debug.Log(collision.transform);
        trackCheckpoints.CarThroughCheckpoint(this, collision.transform);
    }

    public void SetTrackCheckPoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
