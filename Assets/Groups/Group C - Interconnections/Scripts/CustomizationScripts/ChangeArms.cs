using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArms : MonoBehaviour
{
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

    /*public void Randomize()
    {
        currentOption = Random.Range(0, options.Count - 1);
        hatShape.mesh = options[currentOption];
    }*/
}
