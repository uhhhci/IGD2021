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

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHp();
        EquipRandomWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
