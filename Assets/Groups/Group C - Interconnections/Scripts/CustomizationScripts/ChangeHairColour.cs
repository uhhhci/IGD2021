using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHairColour : MonoBehaviour
{
    public MeshRenderer bodyPart;
    public List<Material> options = new List<Material>();

    /*public GameObject Option0;
    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;

    private int currentOption = 0;

    public void FirstOption ()
    {
        currentOption = 0;
        bodyPart.material = options[currentOption];
    }

    public void SecondOption ()
    {
        currentOption++;
        bodyPart.material = options[currentOption];
    }

    public void ThirdOption ()
    {
        currentOption++;
        bodyPart.material = options[currentOption];
    }

    public void FourthOption ()
    {
        currentOption++;
        bodyPart.material = options[currentOption];
    }*/

    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }
        bodyPart.material = options[currentOption];
        

    }

    public void PreviousOption()
    {
        currentOption--;
        if(currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }
        bodyPart.material = options[currentOption];
    }






    


}
