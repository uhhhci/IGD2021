using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUpperBody : MonoBehaviour
{
    public SkinnedMeshRenderer torsoFront;
    public SkinnedMeshRenderer torsoBack;
    public SkinnedMeshRenderer torsoMain;

    public List<Material> torsoFrontOptions = new List<Material>();
    public List<Material> torsoBackOptions = new List<Material>();
    public List<Material> torsoMainOptions = new List<Material>();

    private int currentFrontOption = 0;
    private int currentBackOption = 0;
    private int currentMainOption = 0;

    public void NextOption()
    {
        
        currentFrontOption++; currentBackOption++; currentMainOption++;
        if(currentFrontOption >= torsoFrontOptions.Count && currentBackOption >= torsoBackOptions.Count && currentMainOption >= torsoMainOptions.Count )
        {
            currentFrontOption = 0; currentBackOption = 0; currentMainOption = 0;
            
        }
        
        torsoFront.material = torsoFrontOptions[currentFrontOption];
        torsoBack.material = torsoBackOptions[currentBackOption];
        torsoMain.material = torsoMainOptions[currentMainOption];
        

    }

    public void PreviousOption()
    {
        currentFrontOption--; currentBackOption--; currentMainOption--;

        if (currentFrontOption < 0 && currentBackOption < 0 && currentMainOption < 0)
        {
            currentFrontOption = torsoFrontOptions.Count - 1;
            currentBackOption = torsoBackOptions.Count - 1;
            currentMainOption = torsoMainOptions.Count - 1;
        }
        torsoFront.material = torsoFrontOptions[currentFrontOption];
        torsoBack.material = torsoBackOptions[currentBackOption];
        torsoMain.material = torsoMainOptions[currentMainOption];

        


    } 
}
