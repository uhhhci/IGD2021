using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeArms : MonoBehaviour
{

    public enum ArmOptions
    {
        RightArmFront,
        RightArmMain,
        LeftArmFront,
        LeftArmMain
    }

    public SkinnedMeshRenderer rightArmFront;
    public SkinnedMeshRenderer rightArmMain;

    public SkinnedMeshRenderer leftArmFront;
    public SkinnedMeshRenderer leftArmMain;

    public List<Material> rightArmFrontOptions = new List<Material>();
    public List<Material> rightArmMainOptions = new List<Material>();

    public List<Material> leftArmFrontOptions = new List<Material>();
    public List<Material> leftArmMainOptions = new List<Material>();

    private int currentRightArmFrontOption = 0;
    private int currentRightArmMainOption = 0;

    private int currentLeftArmFrontOption = 0;
    private int currentLeftArmMainOption = 0;

    public void NextOption()
    {
        //Right Arm "Next" set up
        currentRightArmFrontOption++; currentRightArmMainOption++;
        if(currentRightArmFrontOption >= rightArmFrontOptions.Count && currentRightArmMainOption >= rightArmMainOptions.Count )
        {
            currentRightArmFrontOption = 0; currentRightArmMainOption = 0;
            
        }
        
        rightArmFront.material = rightArmFrontOptions[currentRightArmFrontOption];
        rightArmMain.material = rightArmMainOptions[currentRightArmMainOption];

        //Left Arm "Next" set up
        currentLeftArmFrontOption++; currentLeftArmMainOption++;
        if(currentLeftArmFrontOption >= leftArmFrontOptions.Count && currentLeftArmMainOption >= leftArmMainOptions.Count )
        {
            currentLeftArmFrontOption = 0; currentLeftArmMainOption = 0;
            
        }
        
        leftArmFront.material = leftArmFrontOptions[currentLeftArmFrontOption];
        leftArmMain.material = leftArmMainOptions[currentLeftArmMainOption];
    }

    public void PreviousOption()
    {
        //Right Arm "Previous" set up
        currentRightArmFrontOption--; currentRightArmMainOption--;

        if (currentRightArmFrontOption < 0 && currentRightArmMainOption < 0)
        {
            currentRightArmFrontOption = rightArmFrontOptions.Count - 1;
            currentRightArmMainOption = rightArmMainOptions.Count - 1;
        }
        rightArmFront.material = rightArmFrontOptions[currentRightArmFrontOption];
        rightArmMain.material = rightArmMainOptions[currentRightArmMainOption];

        //Left Arm "Previous" set up
        currentLeftArmFrontOption--; currentLeftArmMainOption--;

        if (currentLeftArmFrontOption < 0 && currentLeftArmMainOption < 0)
        {
            currentLeftArmFrontOption = leftArmFrontOptions.Count - 1;
            currentLeftArmMainOption = leftArmMainOptions.Count - 1;
        }
        leftArmFront.material = leftArmFrontOptions[currentLeftArmFrontOption];
        leftArmMain.material = leftArmMainOptions[currentLeftArmMainOption];

    }

    public void Randomize()
    {
        int newIndex = Random.Range(0, rightArmFrontOptions.Count - 1);
        //Right arm
        currentRightArmFrontOption = newIndex;
        rightArmFront.material = rightArmFrontOptions[currentRightArmFrontOption];

        currentRightArmMainOption = newIndex;
        rightArmMain.material = rightArmMainOptions[currentRightArmMainOption];

        //Left arm
        currentLeftArmFrontOption = newIndex;
        leftArmFront.material = leftArmFrontOptions[currentLeftArmFrontOption];

        currentLeftArmMainOption = newIndex;
        leftArmMain.material = leftArmMainOptions[currentLeftArmMainOption];
    }

    public Material GetCurrentSelection(ArmOptions armOption)
    {
        switch (armOption)
        {
            case ArmOptions.RightArmFront:
                return rightArmFrontOptions[currentRightArmFrontOption];
            case ArmOptions.RightArmMain:
                return rightArmMainOptions[currentRightArmMainOption];
            case ArmOptions.LeftArmFront:
                return leftArmFrontOptions[currentLeftArmFrontOption];
            case ArmOptions.LeftArmMain:
                return leftArmMainOptions[currentLeftArmMainOption];
            default:
                return leftArmMainOptions[currentLeftArmMainOption];
        }
    }
}
