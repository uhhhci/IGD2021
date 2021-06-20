using System.Collections;
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
    public GameObject[] players;
    private List<Transform> targets;
    private NavMeshAgent agent;
    private MinifigControllerJ controllerJ;
    string controlScheme;
 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = Minifig.GetComponent<Animator>();
        controllerJ = GetComponent<MinifigControllerJ>();
        explosion = controllerJ.explodeAudioClip;
        audio = GetComponent<AudioSource>();

        players = GameObject.FindGameObjectsWithTag("Player");
        targets = players.Select(go => go.transform).ToList();
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
        if (controlScheme == "AI")
        {
            float distance = Vector3.Distance(targets[2].position, transform.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(targets[2].position);
                controllerJ.PlaySpecialAnimation(MinifigControllerJ.SpecialAnimation.Walk);

                if (distance <= agent.stoppingDistance)
                {
                    //controllerJ.OnEastPress();
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
