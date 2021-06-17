using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHands : MonoBehaviour
{
    public SkinnedMeshRenderer rightHand;
    public SkinnedMeshRenderer leftHand;
    
    public List<Material> rightHandOptions = new List<Material>();
    public List<Material> leftHandOptions = new List<Material>();

    private int currentRightHandOption = 0;
    private int currentLeftHandOption = 0;

    public void NextOption()
    {
        //Right and Left Hand "Next" set up
        currentRightHandOption++; currentLeftHandOption++;
        if(currentRightHandOption >= rightHandOptions.Count && currentLeftHandOption >= leftHandOptions.Count)
        {
            currentRightHandOption = 0; currentLeftHandOption = 0;
            
        }
        
        rightHand.material = rightHandOptions[currentRightHandOption];
        leftHand.material = leftHandOptions[currentLeftHandOption];


    }

    public void PreviousOption()
    {
        //Right and Left Hand "Previous" set up
        currentRightHandOption--; currentLeftHandOption--; 

        if (currentRightHandOption < 0 && currentLeftHandOption < 0)
        {
            currentRightHandOption = rightHandOptions.Count - 1;
            currentLeftHandOption = leftHandOptions.Count - 1;
        }

        rightHand.material = rightHandOptions[currentRightHandOption];
        leftHand.material = leftHandOptions[currentLeftHandOption];

    } 
}
