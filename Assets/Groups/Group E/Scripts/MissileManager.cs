﻿using UnityEngine;

public class MissileManager : MonoBehaviour
{

    public Missile missileTemplateNormal;
    public Missile missileTemplateWhiteBrick;

    public Missile CreateMissile(Transform transform, bool whiteBrick)
    {
        Missile missile = Instantiate(whiteBrick ? missileTemplateWhiteBrick : missileTemplateNormal, transform.position + 7.0f * transform.forward + 1.0f * transform.up, transform.rotation);
        missile.gameObject.SetActive(true);
        missile.Init();
        return missile;
    }
}
