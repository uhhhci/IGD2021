using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHip : MonoBehaviour
{
    public enum HipOptions {
        HipCrotch,
        HipFront,
        HipMain
    }

    public SkinnedMeshRenderer hipCrotch;
    public SkinnedMeshRenderer hipFront;
    public SkinnedMeshRenderer hipMain;

    public List<Material> hipCrotchOptions = new List<Material>();
    public List<Material> hipFrontOptions = new List<Material>();
    public List<Material> hipMainOptions = new List<Material>();

    private int currentHipCrotchOption = 0;
    private int currentHipFrontOption = 0;
    private int currentHipMainOption = 0;

    public void NextOption()
    {
        
        currentHipCrotchOption++; currentHipFrontOption++; currentHipMainOption++;
        if(currentHipCrotchOption >= hipCrotchOptions.Count && currentHipFrontOption >= hipFrontOptions.Count 
            && currentHipMainOption >= hipMainOptions.Count)
        {
            currentHipCrotchOption = 0; currentHipFrontOption = 0; currentHipMainOption = 0;
            
        }
        
        hipCrotch.material = hipCrotchOptions[currentHipCrotchOption];
        hipFront.material = hipFrontOptions[currentHipFrontOption];
        hipMain.material = hipMainOptions[currentHipMainOption];
        

    }

    public void PreviousOption()
    {
        currentHipCrotchOption--; currentHipFrontOption--; currentHipMainOption--;

        if (currentHipCrotchOption < 0 && currentHipFrontOption < 0 && currentHipMainOption < 0)
        {
            currentHipCrotchOption = hipCrotchOptions.Count - 1;
            currentHipFrontOption = hipFrontOptions.Count - 1;
            currentHipMainOption = hipMainOptions.Count - 1;
        }
        hipCrotch.material = hipCrotchOptions[currentHipCrotchOption];
        hipFront.material = hipFrontOptions[currentHipFrontOption];
        hipMain.material = hipMainOptions[currentHipMainOption];

    }

    public void Randomize()
    {
        int newIndex = Random.Range(0, hipCrotchOptions.Count - 1);

        //Hip crotch
        currentHipCrotchOption = newIndex;
        hipCrotch.material = hipCrotchOptions[currentHipCrotchOption];

        //Hip front
        currentHipFrontOption = newIndex;
        hipFront.material = hipFrontOptions[currentHipFrontOption];

        //Hip main
        currentHipMainOption = newIndex;
        hipMain.material = hipMainOptions[currentHipMainOption];

    }

    public Material GetCurrentSelection(HipOptions hipOption)
    {
        switch (hipOption)
        {
            case HipOptions.HipCrotch:
                return hipCrotchOptions[currentHipCrotchOption];
            case HipOptions.HipFront:
                return hipFrontOptions[currentHipFrontOption];
            case HipOptions.HipMain:
                return hipMainOptions[currentHipMainOption];
            default:
                return hipMainOptions[currentHipMainOption];
        }
    }
}
