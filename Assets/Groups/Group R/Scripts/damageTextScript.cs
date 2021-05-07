using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageTextScript : MonoBehaviour
{
    public OurMinifigController player;
    public Text damageText;

    // Update is called once per frame
    void Update()
    {
        damageText.text = player.damage.ToString()+"%";
    }
}
