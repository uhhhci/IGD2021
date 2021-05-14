using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Header("Health")]
    public int maxHp;
    public int currentHp;

    [Header("Properties")]
    public WeaponJsonReader.WeaponType weapon;
    public RowPosition rowPosition;
    public TargetRow targetRow;

    [Header("External factors")]
    public static PhaseHandler.Phase phase;
    public GameObject leftHandWeapon;
    public Vector3 leftHandPosition;

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
    
    public enum TargetRow
    {
        Front, 
        Back
    }

    public void SetMaxHp()
    {
        maxHp = rowPosition == RowPosition.Front ? 100 : 50;
    }

    void EquipRandomWeapon()
    {
        Array values = Enum.GetValues(typeof(WeaponJsonReader.WeaponType));
        System.Random random = new System.Random();
        WeaponJsonReader.WeaponType randomWeapon = (WeaponJsonReader.WeaponType)values.GetValue(random.Next(values.Length));
        weapon = randomWeapon;
        print($"equipped random weapon: {randomWeapon}");
    }

    void SelectRandomTargetRow()
    {
        Array values = Enum.GetValues(typeof(TargetRow));
        System.Random random = new System.Random();
        TargetRow randomTargetRow = (TargetRow)values.GetValue(random.Next(values.Length));
        targetRow = randomTargetRow;
    }

    private void ChangeWeapon(WeaponJsonReader.WeaponType selectedWeapon)
    {
        if (phase == PhaseHandler.Phase.Decision)
        {
            print("Changing Weapon to");
            print(selectedWeapon);
            weapon = selectedWeapon;
        }

        else
        {
            print("Changing Weapon is currently not allowed");
        }
    }

    private void ChangeTargetRow(TargetRow selectedTargetRow)
    {
        if (phase == PhaseHandler.Phase.Decision)
        {
            print("Changing TargetRow to");
            targetRow = selectedTargetRow;
        }
        else
        {
            print("Changing TargetRow is currently not allowed");
        }
    }

    // listen to input events to change the Weapon / targetRow accordingly (only if in Decision phase, of course)
    #region input handling
    private void OnWestPress()
    {
        ChangeTargetRow(TargetRow.Back);
    }

    private void OnSouthPress()
    {
        ChangeWeapon(WeaponJsonReader.WeaponType.Scissors);
    }

    private void OnEastPress()
    {
        ChangeWeapon(WeaponJsonReader.WeaponType.Lego);
    }

    private void OnNorthPress()
    {
        ChangeTargetRow(TargetRow.Front);
    }

    private void OnMoveDpad(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        input.Normalize();

        if (input.Equals(Vector2.up))
        {
            ChangeWeapon(WeaponJsonReader.WeaponType.Paper);
        }
    }
    #endregion


    void ChangeLeftHandWeapon(RowPosition rowPosition, WeaponJsonReader.WeaponType weaponType)
    {  
            // load a gameobject with the correct prefab
            leftHandPosition = transform.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").GetComponent<Transform>().position;
            Weapon[] matchingWeapons = WeaponJsonReader.GetWeapon(weaponType, rowPosition);
            if(matchingWeapons.Length > 0 && leftHandWeapon == null)
            {
                string assetPath = matchingWeapons[0].asset;
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + assetPath) as GameObject;
                leftHandWeapon = Instantiate(prefab, leftHandPosition, transform.rotation);

                // set the weapon as a child of left hand
               leftHandWeapon.transform.parent = transform.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").transform;
               leftHandWeapon.transform.localScale = new Vector3(1, 1, 1);
            }
    }

    void RemoveLeftHandWeapon()
    {
        if (leftHandWeapon != null)
        {
           DestroyImmediate(leftHandWeapon, true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // initialize properties
        SetMaxHp();
        EquipRandomWeapon();
        //ChangeLeftHandWeapon(rowPosition, weapon);
        SelectRandomTargetRow();
    }

    // Update is called once per frame
    void Update()
    {
        phase = PhaseHandler.phase;
        if(phase == PhaseHandler.Phase.Action)
        {
            ChangeLeftHandWeapon(rowPosition, weapon);
        }
        else if(phase == PhaseHandler.Phase.Decision)
        {
            RemoveLeftHandWeapon();
        }
    }
}
