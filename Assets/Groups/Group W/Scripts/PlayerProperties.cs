using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Header("Health")]
    public int maxHp;
    public int currentHp;

    [Header("Properties")]
    public Weapon weapon;
    public RowPosition rowPosition;

    public GameObject scissors;
    public GameObject paper;
    public GameObject lego;
    public Vector3 thePosition;

    // if the row position changes, change the max hp accordingly
    public RowPosition CurrentRowPosition
    {
        get => rowPosition;

        set
        {
            rowPosition = value;
            SetMaxHp();
        }    
    }


    public enum RowPosition
    {
       Front,
       Back
    }

    public enum Weapon
    {
        Lego,
        Paper,
        Scissors
    }

    public void SetMaxHp()
    {
        maxHp = rowPosition == RowPosition.Front ? 100 : 50;
    }

    void EquipRandomWeapon()
    {
        Array values = Enum.GetValues(typeof(Weapon));
        System.Random random = new System.Random();
        Weapon randomWeapon = (Weapon)values.GetValue(random.Next(values.Length));
    }

    void GetChosenWeapon(RowPosition rowPosition, Weapon weapon)
    {
        Vector3 thePosition = transform.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").GetComponent<Transform>().position;

        if (weapon == Weapon.Scissors)
        {
            scissors = Instantiate(scissors, thePosition, transform.rotation);
            // Make Scissors Child of left Hand.
            scissors.transform.parent = transform.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").transform;
            scissors.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (weapon == Weapon.Paper)
        {
            paper = Instantiate(paper, thePosition, transform.rotation);
            // Make Paper Child of left Hand.
            paper.transform.parent = transform.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").transform;
            paper.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            lego = Instantiate(lego, thePosition, transform.rotation);
            // Make Lego Child of left Hand.
            lego.transform.parent = transform.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").transform;
            lego.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void RemoveChosenWeapon()
    {
        if (weapon == Weapon.Scissors)
        {
            Destroy(scissors);
        }
        else if (weapon == Weapon.Paper)
        {
            Destroy(paper);
        }
        else
        {
            Destroy(lego);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHp();
        EquipRandomWeapon();
        GetChosenWeapon(rowPosition, weapon);

    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
