using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFeet : MonoBehaviour
{
    public enum FeetOptions
    {
        RightFoot,
        LeftFoot
    }

    public SkinnedMeshRenderer rightFoot;
    public SkinnedMeshRenderer leftFoot;
    
    public List<Material> rightFootOptions = new List<Material>();
    public List<Material> leftFootOptions = new List<Material>();

    private int currentRightFootOption = 0;
    private int currentLeftFootOption = 0;

    public void NextOption()
    {
        //Right and Left Foot "Next" set up
        currentRightFootOption++; currentLeftFootOption++;
        if(currentRightFootOption >= rightFootOptions.Count && currentLeftFootOption >= leftFootOptions.Count)
        {
            currentRightFootOption = 0; currentLeftFootOption = 0;
            
        }
        
        rightFoot.material = rightFootOptions[currentRightFootOption];
        leftFoot.material = leftFootOptions[currentLeftFootOption];


    }

    public void PreviousOption()
    {
        //Right and Left Foot "Previous" set up
        currentRightFootOption--; currentLeftFootOption--; 

        if (currentRightFootOption < 0 && currentLeftFootOption < 0)
        {
            currentRightFootOption = rightFootOptions.Count - 1;
            currentLeftFootOption = leftFootOptions.Count - 1;
        }

        rightFoot.material = rightFootOptions[currentRightFootOption];
        leftFoot.material = leftFootOptions[currentLeftFootOption];

    }

    public void Randomize()
    {

        int newIndexOption = Random.Range(0, rightFootOptions.Count - 1);

        //Right leg
        rightFoot.material = rightFootOptions[newIndexOption];

        //Left leg
        leftFoot.material = leftFootOptions[newIndexOption];

        //Update index
        currentRightFootOption = newIndexOption;
        currentLeftFootOption = newIndexOption;
        

    }


    public Material GetCurrentSelection(FeetOptions feetOption)
    {
        switch (feetOption)
        {
            case FeetOptions.RightFoot:
                return rightFootOptions[currentRightFootOption];
            case FeetOptions.LeftFoot:
                return leftFootOptions[currentLeftFootOption];
            default:
                return leftFootOptions[currentLeftFootOption];
        }
    }
}
