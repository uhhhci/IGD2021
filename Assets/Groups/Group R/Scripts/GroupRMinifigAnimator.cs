using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupRMinifigAnimator : MonoBehaviour
{
    public OurMinifigController Controller;

    public void enableSword()
    {
        Controller.isHitting = true;
    }

    public void disableSword()
    {
        Controller.isHitting = false;
    }

    public void throwBatarang()
    {
        Controller.fix();
    }

    public void catchBatarang()
    {
        Controller.release();
    }
}
