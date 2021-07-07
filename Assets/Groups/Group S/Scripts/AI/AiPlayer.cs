using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Groups.Group_S.AI {

    [RequireComponent(typeof(MinifigController), typeof(GrabKartPart))]
    public class AiPlayer : MonoBehaviour
    {

        [Tooltip("Were the AI brings parts to")]
        public GameObject homePlate;

        [Tooltip("The minifig")]
        private MinifigController minifig;

        [Tooltip("how close the part can be to the home plate before considering it")]
        public float distThreshold = 5.0f;

        //private NavMeshAgent _navAgent;
        private enum State {
            FIND,
            MOVE_TO,
            RETURN,
        }

        private State _state;
        private GameObject _target;
        private GrabKartPart _grabber;

        // Start is called before the first frame update
        void Start()
        {
            //_navAgent = GetComponent<NavMeshAgent>();
            _grabber = GetComponent<GrabKartPart>();
            minifig = GetComponent<MinifigController>();
            
            //homePlate = GetComponent<GameObject>();
            _state = State.FIND;
        }

        // Update is called once per frame
        void Update()
        {
            switch (_state) {
                case State.FIND: Find(); break;
                case State.MOVE_TO: MoveTo(); break;
                case State.RETURN: Return(); break;

            }
        }

        private float DistanceToHome(Vector3 position) {
            return Vector3.Distance(position, homePlate.transform.position);
        }

        // Find next car part 
        void Find() {
            //Debug.Log($"{gameObject.name} is in find mode");
            GameObject[] all_parts = GameObject.FindGameObjectsWithTag("KartPart");
            GameObject[] parts = all_parts.Where(p => {
                bool grabbed = p.transform.parent != null && p.transform.parent.tag.Equals("Player");
                float dist = DistanceToHome(p.transform.position);
                return !grabbed && dist > distThreshold;
            }).ToArray();

            //Debug.Log($"{gameObject.name}: parts: {parts.Length}");
            if (parts.Length > 0) {
                _target = parts[UnityEngine.Random.Range(0,parts.Length)];
                //Debug.Log($"{gameObject.name} found target!");
                _state  = State.MOVE_TO;
            } else {
                //Debug.Log($"{gameObject.name}: part list is empty");
            }
        }

        // move towards item
        void MoveTo() {
            //Debug.Log($"{gameObject.name} is in move to mode");

            //Part was grabbed by other player
            if (_target.transform.parent != null && _target.transform.parent.tag.Equals("Player")) {
                //Debug.Log($"{gameObject.name}: target was grabbed by other player");
                minifig.StopFollowing();
                _state = State.FIND;
                return;
            }

            Vector3 targetPosition = _target.transform.position;
            minifig.Follow(
                _target.transform,
                onComplete: () => {
                    Debug.Log($"{gameObject.name}: move to completed");
                    _state = State.RETURN;
                }
            );

        }

        private void OnCollisionEnter(Collision other)
        {
            //Debug.Log($"{gameObject.name}: collision happened");

            switch (_state) {
                case State.MOVE_TO:
                    float dist = DistanceToHome(other.gameObject.transform.position);
                    if (other.gameObject == _target) {
                        _grabber.GrabPart();
                        _state = State.RETURN;
                        minifig.StopFollowing();
                    }
                    break;
            }


            /*
            Transform trans;
            if (other.gameObject.TryGetComponent(out collidingVehicleStatProvider))
            {
                _collected.Add(collidingVehicleStatProvider);
                Debug.Log("ENTER: " + _collected.Count);
            };
            */
        }

        // return current grabbed car part
        void Return() {
            //Debug.Log($"{gameObject.name} is in return mode");

            float dist = DistanceToHome(gameObject.transform.position);
            if (dist < UnityEngine.Random.Range(0.5f, dist)) {
                minifig.ClearMoves();
                _grabber.DropPart();
                _target = null;
                _state = State.FIND;
                return;
            }

            Vector3 targetPosition = homePlate.transform.position;
            targetPosition.z += 0.1f;
            minifig.MoveTo(targetPosition, onComplete: () => { 
                //Debug.Log("return complete!!!"); 
                _grabber.DropPart();
                _target = null;
                _state = State.FIND;    
            });
        }
    }
}
