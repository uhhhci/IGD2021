﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    private float mass = 3.0f;
    private float hitForce = 3.0f;
    public Vector3 impact = Vector3.zero;
    private Animator animator;
    public GameObject Minifig;
    private CharacterController controller;
    private AudioClip explosion;
    private AudioSource audio;

    public float lookRadius = 5f;
    public List<GameObject> players = new List<GameObject>();
    private List<Transform> targets;
    private NavMeshAgent agent;
    private MinifigControllerJ controllerJ;
    string controlScheme;
    private bool collided = false;
    public GameObject obstacle;
    private Transform obstacleTransform;
    private CollisionDetector collisionDetector;
    public int ownTeam;
 
    // Start is called before the first frame update
    void Start()
    {
        collisionDetector = this.GetComponent<CollisionDetector>();

        if(collisionDetector.isTeam1 == true)
        {
            ownTeam = 1;
        }
        else
        {
            ownTeam = 2;
        }

        controller = GetComponent<CharacterController>();
        animator = Minifig.GetComponent<Animator>();
        controllerJ = GetComponent<MinifigControllerJ>();
        explosion = controllerJ.explodeAudioClip;
        audio = GetComponent<AudioSource>();
        obstacleTransform = obstacle.transform;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (go.Equals(this.gameObject))
                continue;
            players.Add(go);
        }

        controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
        if (controlScheme == "AI")
        {
            controllerJ.enabled = false;
        }
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in players)
        {
            if (player.GetComponent<AIController>().ownTeam == this.ownTeam)
            {
                players.Remove(player);
            }
        }

        if (controlScheme == "AI" && players.Count != 0)
        {
            foreach (GameObject player in players)
            {
                if (! player.activeSelf)
                {
                    players.Remove(player);
                }
            }

            targets = players.Select(go => go.transform).ToList();

            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;

            foreach (Transform t in targets)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }

            float distance = Vector3.Distance(tMin.position, transform.position);
            float distanceObstacle = Vector3.Distance(obstacleTransform.position, transform.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(tMin.position);
                controllerJ.PlaySpecialAnimation(MinifigControllerJ.SpecialAnimation.Walk);

                if(distanceObstacle <= 6 && ! this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
                {
                    Debug.Log("Jump");
                    controllerJ.PlaySpecialAnimation(MinifigControllerJ.SpecialAnimation.Jump);
                    Physics.IgnoreLayerCollision(gameObject.layer, 21, true);
                }

                if (distance <= agent.stoppingDistance && ! this.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    Debug.Log("Punch");
                    controllerJ.PlaySpecialAnimation(MinifigControllerJ.SpecialAnimation.Punch);
                }           
            }
        }
     
        if (impact.magnitude > 0.2)
        {
            controller.Move(impact * Time.deltaTime);
        }
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

        if(controllerJ.punchable == true)
        {
            controllerJ.PlaySpecialAnimation(MinifigControllerJ.SpecialAnimation.Punch, explosion);
            controllerJ.punchable = false;
        }
    }

    public void AddImpact(Vector3 force)
    {
        var dir = force.normalized;
        impact += dir.normalized * force.magnitude / mass;
    }

    public void OnTriggerStay(Collider other)
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") && other.gameObject.tag == "Player" && other.gameObject.layer != this.gameObject.layer)
        {
            Debug.Log("trigger");
            other.gameObject.GetComponent<AIController>().AddImpact(this.transform.forward * hitForce);
            audio.clip = explosion;
            audio.Play();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
