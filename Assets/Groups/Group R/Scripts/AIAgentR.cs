using System;
using UnityEngine;

public class AIAgentR : MonoBehaviour
{
    public OurMinifigController player;
    public SmashGameR gameManager;

    public Animator animator;
    int atRightSideUpHash = Animator.StringToHash("atRightSideUp");
    bool arrived = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(arrived){
            animator.SetTrigger(atRightSideUpHash);
            arrived = false;
        }
        if (UnityEngine.Random.Range(1, 100) > 98)
        {
            player.Attack();
        }
    }

    public bool MoveToPosition(float z)
    {
        Debug.Log("Moving to ...");
        if (Math.Abs(player.transform.position.z - z) < 0.5f)
        {
            player.RightLeftJump(new Vector2(0, 0));  
            arrived = true;
            return true;
        }
        arrived = false;
        if (player.transform.position.z < z)
        {
            player.RightLeftJump(new Vector2(1, 0));
        }
        if (player.transform.position.z > z)
        {
            player.RightLeftJump(new Vector2(-1, 0));
        }
        return false;
    }


    public void MoveTo(float y){
        player.RightLeftJump(new Vector2(y,0));
    }

    public void JumpTo(float y){
        player.RightLeftJump(new Vector2(y,1));
    }

    public void chooseBehaviour(){
        (int[] platforms,bool[] died) = gameManager.getGameState();

    }
}

