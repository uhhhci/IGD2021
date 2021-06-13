using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Header("Health")]
    public int maxHp;
    public float currentHp;

    [Header("Properties")]
    public PhaseHandler.RowPosition rowPosition;
    public PhaseHandler.Team team;
    public bool isActive = false;
    public Vector3 leftHandPosition;
    public Vector3 startPosition;
    public string playerName;

    [Header("External")]
    public static PhaseHandler.Phase phase;
    DecisionPhase decisionPhase;
    // do net set those via inspector; would be overwritten from DecisionPhase anyway
    public WeaponDefinitions.WeaponType weapon;
    public PhaseHandler.RowPosition targetRow;

    // if the row position changes, change the max hp accordingly
    public PhaseHandler.RowPosition CurrentRowPosition
    {
        get => rowPosition;

        set
        {
            rowPosition = value;
            SetMaxHp();
        }
    }

    public void SetMaxHp()
    {
        maxHp = rowPosition == PhaseHandler.RowPosition.Front ? 100 : 50;
    }
   
    public bool IsAiPlayer()
    {
        string inputScheme = transform.parent.GetComponent<PlayerInput>().defaultControlScheme;
        // TODO get ai/bot string from interconnections group
        return inputScheme == "AI";
    }

    // Start is called before the first frame update
    void Start()
    {
        // initialize properties
        SetMaxHp();
        startPosition = transform.position;
        decisionPhase = gameObject.GetComponent<DecisionPhase>();
        IsAiPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = decisionPhase.selectedWeapon;
        targetRow = decisionPhase.selectedTargetRow;
        leftHandPosition = transform.parent.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").GetComponent<Transform>().position;
    }
}
