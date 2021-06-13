using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupRMinifigAnimator : MonoBehaviour
{
    public OurMinifigController Controller;

    public void enableSword()
    {
        Controller.setHitting(true);
    }

    public void disableSword()
    {
        Controller.setHitting(false);
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
