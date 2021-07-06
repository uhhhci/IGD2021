using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseOutfitChanger : MonoBehaviour
{
    public SkinnedMeshRenderer bodyPart;
    public List<Material> options = new List<Material>();

    private int currentOption = 0;

    public void Randomize()
    {
        currentOption = Random.Range(0, options.Count - 1);
        bodyPart.material = options[currentOption];
    }

    public Material GetCurrentSelection()
    {
        return options[currentOption];
    }
}
