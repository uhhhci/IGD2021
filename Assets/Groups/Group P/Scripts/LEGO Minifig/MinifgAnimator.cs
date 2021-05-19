using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {
    public class MinifigAnimator : MonoBehaviour
    {
        public MinifigController Controller;


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
}