using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomizeSelection : MonoBehaviour
{
       
    public void RandomizeCharacter()
    {
        //hair
        //Script hairScript = hair.GetComponent<Script>();
        GameObject hair = GameObject.Find("Hair");
        ChangeHair hairScript = hair.GetComponent<ChangeHair>();
        int idx_hair = Random.Range(0, hairScript.options.Count);
        hairScript.bodyPart.mesh = hairScript.options[idx_hair];
    }
}

 //GameObject go = GameObject.Find("mainCharacter");
 //controllerScript cs = go.GetComponent<controllerScript>();
 //float thisObjectMove = cs.move;
