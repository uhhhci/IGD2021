using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CharacterCustomizationMenu : MonoBehaviour
{
    public GameObject character;
    public void SaveButton()
    {
        PrefabUtility.SaveAsPrefabAsset(character,"Assets/Groups/Group C - Interconnections/Prefabs/Minifig Character.prefab");
    }
}
