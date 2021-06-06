using System.Collections.Generic;
using UnityEngine;

namespace Groups.Group_S
{
    public class BuildPartCollector : MonoBehaviour
    {
        private HashSet<GameObject> _collected = new HashSet<GameObject>();
        
        private void OnCollisionEnter(Collision other)
        {
            //if (!other.gameObject.CompareTag("PartKart")) return;
            _collected.Add(other.gameObject);
            Debug.Log("ENTER: " + _collected.Count);
        }

        private void OnCollisionExit(Collision other)
        {
            //if (!other.gameObject.CompareTag("PartKart")) return;
            _collected.Remove(other.gameObject);
            Debug.Log("EXIT: " + _collected.Count);
        }
    }
}
