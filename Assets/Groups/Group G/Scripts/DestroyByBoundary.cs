using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        EventSystemListeners.main.RemoveListener(other.gameObject);
        Destroy(other.gameObject);
    }
}
