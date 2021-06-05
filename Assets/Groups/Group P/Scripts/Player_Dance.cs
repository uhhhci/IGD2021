using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP
{
    public class Player_Dance : MonoBehaviour
    {
        Animator animator;
        public GameObject minifig;
        int hashmove0 = Animator.StringToHash("Spin");
        int hashmove1 = Animator.StringToHash("Air Guitar");
        int[] danceMovesHashes;

        int hashbeat0 = Animator.StringToHash("Jump");
        int hashbeat1 = Animator.StringToHash("Turn Left");
        int hashbeat2 = Animator.StringToHash("Turn Right");
        int currentMove;
        int[] basicMovesHashes;

        int hashstart = Animator.StringToHash("Start");

        int wait;

        private void Start()
        {
            animator = minifig.GetComponent<Animator>();
            basicMovesHashes = new int[] { hashbeat1, hashbeat2 };
            danceMovesHashes = new int[] { hashmove0, hashmove1 };
            currentMove = 0;
            GameEventSystem.current.onHit += DanceMove;
            GameEventSystem.current.onBeat += BasicMove;
            GameEventSystem.current.onStartDance += StartDance;

            wait = 0;
        }

        void DanceMove()
        {
            //Debug.Log("Dance");
            int hash = Random.Range(0, danceMovesHashes.Length);
            animator.SetTrigger(danceMovesHashes[hash]);
            wait += 3;
        }

        void BasicMove()
        {
            if (wait > 0)
            {
                wait--;
            }
            else
            {
                //Debug.Log("Move");
                //int hash = Random.Range(0, basicMovesHashes.Length);
                animator.SetTrigger(basicMovesHashes[currentMove]);
                currentMove ^= 1;
            }
        }

        void StartDance()
        {
            animator.SetTrigger(hashstart);
        }

        private void OnDestroy()
        {
            GameEventSystem.current.onHit -= DanceMove;
        }
    }
}