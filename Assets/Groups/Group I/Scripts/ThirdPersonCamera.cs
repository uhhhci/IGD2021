using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Start()
    {
        keepDistance();
        this.transform.LookAt(player.position);
        this.transform.Rotate(Vector3.right, -25f);
    }

    void Update()
    {
        keepDistance();
    }

    private void keepDistance()
    {
        this.transform.position = player.position + 5 * Vector3.up + 5 * Vector3.forward;
    }
}
