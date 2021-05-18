using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinifigAnimatorModified : MonoBehaviour
{
    public MinifigControllerModified Controller;


    // Animation event.
    public void StepFoot()
    {
        Controller.StepFoot();
    }

    // Animation event.
    public void LiftFoot()
    {
        Controller.LiftFoot();
    }
}
