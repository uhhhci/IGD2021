using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Implements the functionality for a player figure to grab a part of a kart.
 * Player must have a Collider component and part must be tagged with "KartPart", have a Collider and a RigidBody component.
 *
 * Freeze all rotations and positions on the part to avoid parts floating around.
 *
 * Grabbing and dropping is triggered by pressing east (e.g. Q with WASD).
 */
public class GrabKartPart : MonoBehaviour
{
    public GameObject _grabbable;
    public GameObject _grabbed;
    private void OnCollisionEnter(Collision other)
    {
        // Object is only grabbable when it's a part and not parented by anything, especially not a player
        if (other.gameObject.CompareTag("KartPart") && (other.transform.parent == null || !other.transform.parent.CompareTag("Player") ))
        {
            _grabbable = other.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // When there is no longer a collision with the current grabbable object, it is not grabbable anymore
        if (other.gameObject.CompareTag("KartPart") && other.gameObject == _grabbable)
        {
            _grabbable = null;
        }
    }

    void OnEastPress()
    {
        // Drop old object
        if (_grabbed != null)
        {
            _grabbed.transform.parent = null;
            _grabbed = null;
        }
        // Grab new object
        else if (_grabbable != null)
        {
            _grabbed = _grabbable;
            _grabbable.transform.parent = transform;
        }
    }
}
