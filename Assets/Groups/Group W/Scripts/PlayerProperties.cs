using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Header("Health")]
    public int maxHp;
    public int currentHp;

    [Header("Properties")]
    public Weapon weapon;
    public RowPosition rowPosition;
    public TargetRow targetRow;

    [Header("External factors")]
    public static PhaseHandler.Phase phase;

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
        Array values = Enum.GetValues(typeof(Weapon));
        System.Random random = new System.Random();
        Weapon randomWeapon = (Weapon)values.GetValue(random.Next(values.Length));
        weapon = randomWeapon;
    }

    void SelectRandomTargetRow()
    {
        Array values = Enum.GetValues(typeof(TargetRow));
        System.Random random = new System.Random();
        TargetRow randomTargetRow = (TargetRow)values.GetValue(random.Next(values.Length));
        targetRow = randomTargetRow;
    }

    private void ChangeWeapon(Weapon selectedWeapon)
    {
        if (IsActionAllowed())
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
        if (IsActionAllowed())
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
        ChangeWeapon(Weapon.Scissors);
    }

    private void OnEastPress()
    {
        ChangeWeapon(Weapon.Lego);
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
            ChangeWeapon(Weapon.Paper);
        }
    }
    #endregion

    // only change things during the decision phase!
    public static Boolean IsActionAllowed()
    {
        if (phase == PhaseHandler.Phase.Decision)
        {
            return true;
        }

        else
        {
            return false;
        }
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
        // initialize properties
        SetMaxHp();
        EquipRandomWeapon();
<<<<<<< HEAD
        GetChosenWeapon(rowPosition, weapon);

=======
        SelectRandomTargetRow();
>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

        

=======
        phase = PhaseHandler.phase;
>>>>>>> main
    }
}
