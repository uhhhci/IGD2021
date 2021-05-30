using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionPhase : MonoBehaviour
{
    public PhaseHandler.Phase phase;
    public TextAsset weaponTypesJsonFile;
    public WeaponTypes weaponTypes;

    private float moveStopDistance = 1f;
    public static int activePlayerIndex = 0;
    PlayerProperties player;
    private MinifigControllerGroupW playerMinifigController;
    private WeaponDefinitions.WeaponType playerWeapon;
    public PhaseHandler.RowPosition playerTargetRow;
    public static List<PlayerProperties> players;
    bool isActionPhase;
    public GameObject leftHandWeapon;
    public Vector3 leftHandPosition;

    // calculates the damage dealt by currentPlayer to targetPlayer
    // takes the base damage and its multiplier (derived from the weapon types) into account
    float CalculateDamage(PlayerProperties targetPlayer)
    {
        Weapon[] matchingWeapons = WeaponDefinitions.GetWeapon(player.weapon, player.rowPosition);
        if (matchingWeapons.Length > 0)
        {
            int baseDamage = Int16.Parse(matchingWeapons[0].power);
            float multiplier = GetMultiplier(player.weapon, targetPlayer.weapon);
            return baseDamage * multiplier;
        }

        else
        {
            return 0f;
        }
    }

    // returns a damage multipler based on the equipped weapon type and the target weapon type strength/weakness
    float GetMultiplier(WeaponDefinitions.WeaponType equippedWeaponType, WeaponDefinitions.WeaponType targetWeaponType)
    {
        WeaponType equippedWeaponTypeInfo = Array.FindAll<WeaponType>(weaponTypes.weaponTypes, weaponType => weaponType.type == equippedWeaponType.ToString())[0];
        if (targetWeaponType.ToString() == equippedWeaponTypeInfo.strength)
        {
            return 2f;
        }

        else if (targetWeaponType.ToString() == equippedWeaponTypeInfo.weakness)
        {
            return 0.5f;
        }

        else
        {
            return 1f;
        }
    }

    // searches for the player of the other team by chosing the other team and the target row
    PlayerProperties GetTargetPlayer()
    {
        // opponent team is the team that is not the own team
        PhaseHandler.Team opponentTeam = player.team == PhaseHandler.Team.Left ? PhaseHandler.Team.Right : PhaseHandler.Team.Left;
        List<PlayerProperties> matchingPlayers = players.FindAll(somePlayer => somePlayer.team == opponentTeam
                                                && somePlayer.rowPosition == player.targetRow);

        print($"Player { player.playerName} is targeting player from team { opponentTeam} on row { player.targetRow}.");
        if (matchingPlayers.Count == 1)
        {
            print($"Matching target player is: {matchingPlayers[0].playerName}");
            return matchingPlayers[0];
        }
        
        else
        {
            // more or less than one player found
            print($"found {matchingPlayers.Count} matching players, but there should be only exactly 1");
            if(matchingPlayers.Count > 1)
            {
                print("found following players:");
                foreach (PlayerProperties player in matchingPlayers)
                {
                    print(player.playerName);
                }
            }
            throw new InvalidOperationException();
        }
    }

    // moves to the target and attacks it
    void MoveToAttackTarget(PlayerProperties targetPlayer)
    {
        Vector3 targetPosition = targetPlayer.transform.position;

        // stop *in front of* target character, not on top
        // if activePlayer.z positive, +=; else -=
        if (Math.Sign(player.transform.position.z) == -1)
        {
            targetPosition.z -= moveStopDistance;
        }
        else
        {
            targetPosition.z += moveStopDistance;
        }

        playerMinifigController.MoveTo(targetPosition, onComplete: () => { MeleeAttack(targetPlayer); });
    }

    bool CanPlayerAttack(PlayerProperties targetPlayer)
    {
        bool areBothOnFrontRow = player.CurrentRowPosition == PhaseHandler.RowPosition.Front && targetPlayer.CurrentRowPosition == PhaseHandler.RowPosition.Front;
        bool isPlayerOnBackRow = player.CurrentRowPosition == PhaseHandler.RowPosition.Back;
        bool isTargetAlive = targetPlayer.currentHp > 0;
        bool isPlayerAlive = player.currentHp > 0;

        //print($"is target alive: {isTargetAlive}");
        //print($"is player alive: {isPlayerAlive}");
        //print($"both on front row (would be ok): {areBothOnFrontRow}");
        //print($"is player on back row (would be ok): {isPlayerOnBackRow}");

        if (isTargetAlive && isPlayerAlive)
        {
            // true if one of them evaluates to true
            return areBothOnFrontRow || isPlayerOnBackRow;
        }

        else
        {
            print("either the attacking player, or the target are dead.");
            return false;
        }
    }

    // plays an attack animation, deals damage and returns to the start position
    void MeleeAttack(PlayerProperties targetPlayer)
    {
        playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.HatSwap, onSpecialComplete: (x) => {
            DealDamage(targetPlayer);
            print("finished attack");
            ReturnToStartPosition(targetPlayer);
        });
    }

    void DealDamage(PlayerProperties targetPlayer)
    {
        print("now dealing damage");
        // calculate damage
        float damage = CalculateDamage(targetPlayer);
        // lower hp of target, but prevent hp from falling below 0
        float newHp = targetPlayer.currentHp - damage;
        targetPlayer.currentHp = newHp > 0 ? newHp : 0;
        print($"damage to target ({targetPlayer.playerName}): {damage}. New HP: {targetPlayer.currentHp}");

        if (targetPlayer.currentHp <= 0)
        {
            KillPlayer(targetPlayer);
        }
    }

    // TODO method got too small after refactoring, just use it directly
    void ReturnToStartPosition( PlayerProperties targetPlayer)
    {
        playerMinifigController.MoveTo(player.startPosition, onComplete: () => { RotateBack(player, targetPlayer); });
    }

    void RotateBack(PlayerProperties activePlayer, PlayerProperties targetPlayer)
    {
       
        // TODO player hp bar should stay on top of player instead of rotating with him
        // face to the correct direction again (change rotation)
        print("now rotating back");
        Vector3 originalRotation = targetPlayer.transform.position;
        // when the animation is finished, it's the next players turn
        playerMinifigController.TurnTo(originalRotation, onComplete: () => { PhaseHandler.SetNextActivePlayer(); });
    }

    // player will fall down to ground
    void KillPlayer(PlayerProperties player)
    {
        // only the minfig should fall down, not the attached components like the hp bar
        GameObject minifigCharacter = player.transform.parent.GetComponent<MinifigControllerGroupW>().Minifig;

        // TODO do this SLOWLY, maybe create a dying animation
        // TODO prevent player from being pushed around
        var rotationVector = minifigCharacter.transform.rotation.eulerAngles;
        rotationVector.x = -90;
        minifigCharacter.transform.rotation = Quaternion.Euler(rotationVector);
        print($"player ({player.playerName}) is dead now");
    }

    void RemoveLeftHandWeapon()
    {
        if (leftHandWeapon != null)
        {
            print("removed left hand weapon");
            DestroyImmediate(leftHandWeapon, true);
        }
    }

    public void ChangeLeftHandWeapon(PhaseHandler.RowPosition rowPosition, WeaponDefinitions.WeaponType weaponType)
    {
        print("equipping new left hand weapon");
        Transform leftHandTransform = player.transform.parent.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").transform;
        // weapon color should stay the same as previous
        Color color = leftHandWeapon != null ? leftHandWeapon.GetComponent<Renderer>().material.color : Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        RemoveLeftHandWeapon();
        // spawns a new weapon and sets it as leftHandWeapon
        leftHandWeapon = SpawnNewWeapon(rowPosition, weaponType, color);
        leftHandWeapon.transform.parent = leftHandTransform;
    }

    // overloaded method to spawn a specific asset instead of the one derived from rowPosition and weaponType
    public void ChangeLeftHandWeapon(String assetPath)
    {
        RemoveLeftHandWeapon();
        print("changing left hand weapon via asset path");
        Transform leftHandTransform = player.transform.parent.Find("Minifig Character/jointScaleOffset_grp/Joint_grp/detachSpine/spine01/spine02/spine03/spine04/spine05/spine06/shoulder_L/armUp_L/arm_L/wristTwist_L/wrist_L/hand_L/finger01_L").transform;
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        leftHandWeapon = LoadNewWeapon(assetPath, new Vector3(1f, 1f, 1f), randomColor);
        leftHandWeapon.transform.parent = leftHandTransform;
    }

    GameObject SpawnNewWeapon(PhaseHandler.RowPosition rowPosition, WeaponDefinitions.WeaponType weaponType, Color color)
    {
        // load a gameobject with the correct prefab
        Weapon[] matchingWeapons = WeaponDefinitions.GetWeapon(weaponType, rowPosition);

        if (matchingWeapons.Length > 0)
        {
            string assetPath = matchingWeapons[0].asset;
            GameObject newWeapon = LoadNewWeapon(assetPath, new Vector3(0.3f, 0.3f, 0.3f), color);
            return newWeapon;
        }
        else
        {
            // no matching weapon type was found
            throw new InvalidOperationException();
        }
    }

    // load a gameobject with the correct prefab
    GameObject LoadNewWeapon(String assetPath, Vector3 scale, Color color)
    {
        GameObject newWeapon;
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + assetPath) as GameObject;
        newWeapon = Instantiate(prefab, leftHandPosition, player.transform.rotation);
        newWeapon.transform.localScale = scale;
        newWeapon.GetComponent<Renderer>().material.color = color;
        return newWeapon;
    }


    // throws the equipped weapon from activePlayer to targetPlayer
    IEnumerator ThrowWeapon(PlayerProperties targetPlayer, Action onComplete)
    {
        Color color = leftHandWeapon != null ? leftHandWeapon.GetComponent<Renderer>().material.color : Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        print("is back row; now throwing weapon");
        GameObject throwableWeapon = SpawnNewWeapon(player.CurrentRowPosition, player.weapon, color);

        // should get a rigidbody to be able to throw it, if not already available
        if(throwableWeapon.GetComponent<Rigidbody>() != null)
        {
            throwableWeapon.AddComponent<Rigidbody>();
        }

        // following code is adapted from https://gist.github.com/marcelschmidt1337/e46d166b639c06af3ba896fcb8412be4
        float throwAngle = 45.0f;
        float gravity = 9.8f;

        Vector3 target = targetPlayer.transform.parent.transform.position;
        Vector3 start = throwableWeapon.transform.position;

        float targetDistance = Vector3.Distance(start, target);

        // Calculate the velocity needed to throw the object to the target at specified angle
        float weaponVelocity = targetDistance / (Mathf.Sin(2 * throwAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X & Y componenent of the velocity
        float Vx = Mathf.Sqrt(weaponVelocity) * Mathf.Cos(throwAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(weaponVelocity) * Mathf.Sin(throwAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = targetDistance / Vx;
        print($"flight duration: {flightDuration}");

        // remove the equipped weapon and throw the new one;
        RemoveLeftHandWeapon();

        float elapsedTime = 0;
        while (elapsedTime < flightDuration)
        {
            throwableWeapon.transform.Translate(0, (Vy - (gravity * elapsedTime)) * Time.deltaTime, Vx * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if(elapsedTime >= flightDuration)
        {
            print("finished throwing weapon");
            onComplete.Invoke();
            DestroyImmediate(throwableWeapon, true);
        }
    }


    public void DoAction()
    {
        PlayerProperties targetPlayer = GetTargetPlayer();

        // checks for restrictions before attacking
        if (CanPlayerAttack(targetPlayer))
        {
            // TODO check if player is front or back row to choose whether player should move or throw weapon
            // -> front should move and swing weapon, back should throw weapon
            if(player.CurrentRowPosition == PhaseHandler.RowPosition.Back)
            {
                Coroutine throwWeaponCoroutine = StartCoroutine(ThrowWeapon(targetPlayer, onComplete: () => {
                    DealDamage(targetPlayer);
                    PhaseHandler.SetNextActivePlayer();
                }));
            }

            else
            {
                MoveToAttackTarget(targetPlayer);
            }
        }
        else
        {
            print($"target ({targetPlayer.playerName}) can currently not be attacked. Switching to next player now.");
            // somehow this has to be done via callback, otherwise the next phase won't be triggered
            // PhaseHandler.SetNextActivePlayer();
            // StartCoroutine(SetNextActivePlayer(onComplete: () => { PhaseHandler.SetNextActivePlayer(); }));

            MinifigControllerGroupW.SpecialAnimation specialAnimation = player.currentHp <= 0 ? MinifigControllerGroupW.SpecialAnimation.LookingDown : MinifigControllerGroupW.SpecialAnimation.IdleImpatient;

            playerMinifigController.PlaySpecialAnimation(specialAnimation, onSpecialComplete: (x) => {
                PhaseHandler.SetNextActivePlayer();
            });
        }

    }

    // this was just a test, can be deleted
    IEnumerator SetNextActivePlayer(Action onComplete)
    {
        print("setting next active player from ActionPhase.cs");
        // PhaseHandler.SetNextActivePlayer();
        onComplete.Invoke();
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponTypes = JsonUtility.FromJson<WeaponTypes>(weaponTypesJsonFile.text);
        player = gameObject.GetComponent<PlayerProperties>();
        playerMinifigController = gameObject.transform.parent.GetComponent<MinifigControllerGroupW>();
    }

    // Update is called once per frame
    void Update()
    {
        leftHandPosition = player.leftHandPosition;
        players = PhaseHandler.players;
    }
}


[System.Serializable]
public class WeaponTypes
{
    public WeaponType[] weaponTypes;
}


[System.Serializable]
public class WeaponType
{
    public string type;
    public string weakness;
    public string strength;
}
