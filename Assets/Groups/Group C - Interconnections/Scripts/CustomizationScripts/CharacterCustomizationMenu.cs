using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomizationMenu : MonoBehaviour
{
    public GameObject character;
  
    public void SaveButton()
    {
        Button savebutton = GameObject.Find("SaveButton").GetComponent<Button>();
        Button randombutton = GameObject.Find("RandomizeButton").GetComponent<Button>();
        Button startgame = GameObject.Find("StartButton").GetComponent<Button>();

        Text color_player = GameObject.Find("MessageColor").GetComponent<Text>();
        Text messagetitle = GameObject.Find("Message1").GetComponent<Text>();
        messagetitle.text = "Player saved! :";

        color_player.color = InputManager.Instance.players_colors[0];
        color_player.text = InputManager.Instance.players_colors_names[0];
        
        PlayerPrefs.SetString("PLAYER"+InputManager.Instance.ids_players.ToString()+"_NAME", InputManager.Instance.players_colors_names[0]);
        InputManager.Instance.players_colors.RemoveAt(0);
        InputManager.Instance.players_colors_names.RemoveAt(0);
        InputManager.Instance.ids_players.RemoveAt(0);

        if (InputManager.Instance.players_colors.Count == 0) {
            savebutton.interactable = false;
            randombutton.interactable = false;
        }
        
        Debug.Log("color saved");
        PrefabUtility.SaveAsPrefabAsset(character,"Assets/Groups/Group C - Interconnections/Prefabs/Minifig Character.prefab");
    }

    public void RandomizeCharacter()
    {
        int up_custom = Random.Range(0,2);

        switch(up_custom){
            case 0: 
                //hair
                GameObject hair = GameObject.Find("Hair");
                ChangeHair hairScript = hair.GetComponent<ChangeHair>();
                int idx_hair = Random.Range(0, hairScript.options.Count - 1);
                hairScript.bodyPart.mesh = hairScript.options[idx_hair];
                Debug.Log("Hair");
                break;
            case 1:
                //hat
                GameObject hat = GameObject.Find("Hats");
                string text2 = string.Empty;
                foreach(var component in hat.GetComponents(typeof(Component)))
                {
                    text2 += component.GetType().ToString() + " ";
                }
                Debug.Log(text2);
                Accessories hatScript = hat.GetComponent<Accessories>();
                int idx_hat = Random.Range(0, hatScript.options.Count - 1);
                hatScript.hatShape.mesh = hatScript.options[idx_hat];
                Debug.Log("Hats");
                break;
            case 2: 
                //Hair-hat color
                GameObject haircolor = GameObject.Find("Hair-/HatColor");
                ChangeHairColour haircolorScript = haircolor.GetComponent<ChangeHairColour>();
                int idx_haircolor = Random.Range(0, haircolorScript.options.Count - 1);
                haircolorScript.bodyPart.material = haircolorScript.options[idx_haircolor];
                Debug.Log("Hair color");
                break;
        }


        //face
        GameObject faces = GameObject.Find("FaceGesture");
        ChangeFace faceScript = faces.GetComponent<ChangeFace>();
        int idx_face = Random.Range(0, faceScript.options.Count - 1);
        faceScript.bodyPart.material = faceScript.options[idx_face];
        Debug.Log("face");


        //face tone
        GameObject faceTone = GameObject.Find("FaceTone");
        ChangeFaceTone faceToneScript = faceTone.GetComponent<ChangeFaceTone>();
        int idx_faceTone = Random.Range(0, faceToneScript.options.Count);
        faceToneScript.bodyPart.material = faceToneScript.options[idx_faceTone];
         Debug.Log("face tone");

        //upper body
        GameObject upperBody = GameObject.Find("UpperBody");
        ChangeUpperBody upperBodyScript = upperBody.GetComponent<ChangeUpperBody>();

        int idx_upperBody_front = Random.Range(0, upperBodyScript.torsoFrontOptions.Count);
        upperBodyScript.torsoFront.material = upperBodyScript.torsoFrontOptions[idx_upperBody_front];

        int idx_upperBody_back = Random.Range(0, upperBodyScript.torsoBackOptions.Count);
        upperBodyScript.torsoBack.material = upperBodyScript.torsoBackOptions[idx_upperBody_back];

        int idx_upperBody_main = Random.Range(0, upperBodyScript.torsoMainOptions.Count);
        upperBodyScript.torsoMain.material = upperBodyScript.torsoMainOptions[idx_upperBody_main];
         Debug.Log("upper body");

        //arms
        GameObject arms = GameObject.Find("Arms");
        ChangeArms armsScript = arms.GetComponent<ChangeArms>();

        int idx_right_front = Random.Range(0, armsScript.rightArmFrontOptions.Count);
        armsScript.rightArmFront.material = armsScript.rightArmFrontOptions[idx_right_front];

        int idx_right_main = Random.Range(0, armsScript.rightArmMainOptions.Count);
        armsScript.rightArmMain.material = armsScript.rightArmMainOptions[idx_right_main];

        int idx_left_front = Random.Range(0, armsScript.leftArmFrontOptions.Count);
        armsScript.leftArmFront.material = armsScript.leftArmFrontOptions[idx_left_front];

        int idx_left_main = Random.Range(0, armsScript.leftArmMainOptions.Count);
        armsScript.leftArmMain.material = armsScript.leftArmMainOptions[idx_left_main];
         Debug.Log("arms");


        //hands
        GameObject hands = GameObject.Find("Hands");
        ChangeHands handsScript = hands.GetComponent<ChangeHands>();

        int idx_right_hand = Random.Range(0, handsScript.rightHandOptions.Count);
        handsScript.rightHand.material = handsScript.rightHandOptions[idx_right_front];

        int idx_left_hand = Random.Range(0, handsScript.leftHandOptions.Count);
        handsScript.leftHand.material = handsScript.leftHandOptions[idx_left_hand];
         Debug.Log("hands");

        //hip
        GameObject hip = GameObject.Find("HipSelection");
        ChangeHip hipScript = hip.GetComponent<ChangeHip>();

        int idx_hipCrotch = Random.Range(0, hipScript.hipCrotchOptions.Count);
        hipScript.hipCrotch.material = hipScript.hipCrotchOptions[idx_hipCrotch];

        int idx_hipFront = Random.Range(0, hipScript.hipFrontOptions.Count);
        hipScript.hipFront.material = hipScript.hipFrontOptions[idx_hipFront];

        int idx_hipMain = Random.Range(0, hipScript.hipMainOptions.Count);
        hipScript.hipMain.material = hipScript.hipMainOptions[idx_hipMain];
         Debug.Log("hip");


        //legs
        GameObject legs = GameObject.Find("Legs");
        ChangeLegs legsScript = legs.GetComponent<ChangeLegs>();

        int idx_rightLegFront = Random.Range(0, legsScript.rightLegFrontOptions.Count);
        legsScript.rightLegFront.material = legsScript.rightLegFrontOptions[idx_rightLegFront];

        int idx_rightLegMain = Random.Range(0, legsScript.rightLegMainOptions.Count);
        legsScript.rightLegMain.material = legsScript.rightLegMainOptions[idx_rightLegMain];

        int idx_rightLegSide = Random.Range(0, legsScript.rightLegSideOptions.Count);
        legsScript.rightLegSide.material = legsScript.rightLegSideOptions[idx_rightLegSide];


        int idx_leftleg_front = Random.Range(0, legsScript.leftLegFrontOptions.Count);
        legsScript.leftLegFront.material = legsScript.leftLegFrontOptions[idx_leftleg_front];

        int idx_leftleg_side = Random.Range(0, legsScript.leftLegSideOptions.Count);
        legsScript.leftLegSide.material = legsScript.leftLegSideOptions[idx_leftleg_side];

        int idx_leftleg_main = Random.Range(0, legsScript.leftLegMainOptions.Count);
        legsScript.leftLegMain.material = legsScript.leftLegMainOptions[idx_leftleg_main];
         Debug.Log("legs");


        //feet
        GameObject feet = GameObject.Find("Feet");
        ChangeFeet feetScript = feet.GetComponent<ChangeFeet>();

        int idx_right_foot = Random.Range(0, feetScript.rightFootOptions.Count);
        feetScript.rightFoot.material = feetScript.rightFootOptions[idx_right_foot];

        int idx_left_foot = Random.Range(0, feetScript.leftFootOptions.Count);
        feetScript.leftFoot.material = feetScript.leftFootOptions[idx_left_foot];
         Debug.Log("feet");

    }
}
