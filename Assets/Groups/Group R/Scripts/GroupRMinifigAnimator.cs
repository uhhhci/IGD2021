using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupRMinifigAnimator : MonoBehaviour
{
    public OurMinifigController Controller;

    public void enableSword()
    {
        Debug.Log("Moin");
        Controller.isHitting = true;
    }

        public void disableSword()
    {
        Debug.Log("Haide");
        Controller.isHitting = false;
    }
}
