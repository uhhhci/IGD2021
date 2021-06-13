using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueParty : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    public void playAnimation() {
        anim.SetTrigger("Start");
    }

    public bool isFinished() {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("Done");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
