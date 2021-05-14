using System;
using UnityEngine;
using UnityEngine.Assertions;

public class WeaponJsonReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public static Weapons weapons; 
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(jsonFile);
        weapons = JsonUtility.FromJson<Weapons>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum WeaponType
    {
        Lego,
        Paper,
        Scissors,
    }

    // searches through all availabe weapons and returns the ones that match the weapon type and row position
    public static Weapon[] GetWeapon(WeaponType weaponType, PlayerProperties.RowPosition rowPosition)
    {
        return Array.FindAll<Weapon>(weapons.weapons, weapon => weapon.type == weaponType.ToString()
                                                            && weapon.row == rowPosition.ToString()); 
    }
}

[System.Serializable]
public class Weapons
{
    public Weapon[] weapons;
}


[System.Serializable]
public class Weapon
{
    public string asset;
    public string power;
    public string row;
    public string type;
}
