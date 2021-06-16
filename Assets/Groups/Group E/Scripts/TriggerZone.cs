using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    void OnTriggerEnter(Collider collision)
    {
        //if (collision.TryGetComponent<>(out Main player))
        //if (collision.name == "Main")
        if(collision.CompareTag("Player"))
        {
            trackCheckpoints.CarThroughCheckpoint(this, collision.transform);
        }

    }

    public void SetTrackCheckPoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
