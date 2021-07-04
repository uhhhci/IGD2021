using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentScript_E : MonoBehaviour
{
    public Transform Checkpoints;
    private List<TriggerZone> triggerZones;
    public Transform target;
    NavMeshAgent agent;
    private int NextCheckPoint;
    PlayerStats thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = this.GetComponent<PlayerStats>();        

        triggerZones = new List<TriggerZone>();
        foreach (Transform checkpointSingleTransform in Checkpoints)
        {
            TriggerZone triggerZone = checkpointSingleTransform.GetComponent<TriggerZone>();
            triggerZones.Add(triggerZone);
        }

        NextCheckPoint = 1;
        target = triggerZones[NextCheckPoint].transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled && agent.isOnNavMesh)
        {
        target = triggerZones[NextCheckPoint].transform;
        agent.SetDestination(target.position);
        //Debug.Log("Agent position: " + agent.transform.position + "\nAgent steering target: " + agent.steeringTarget);
        if (agent.steeringTarget.x == target.position.x && agent.steeringTarget.z == target.position.z)
        {
            NextCheckPoint = (NextCheckPoint + 1) % triggerZones.Count;
            //StartCoroutine(WaitSeconds(1));
        }
        if(thePlayer.hasPowerup)
        {
            StartCoroutine(thePlayer.power.UsePowerup(thePlayer.gameObject));
        }
    }
    }

    public IEnumerator DisableAgentTemp()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(3f);
        agent.enabled = true;
    }

    public IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
