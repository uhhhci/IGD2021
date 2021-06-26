using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int rounds;
    public Text textRounds;
    public Text textPosition;
    public Text textPowerup;
    public int CurrentZone;
    public Transform lastZone;
    public int position;
    private static int WAYPOINT_VALUE = 1000;
    private static int LAP_VALUE = 1000000;
    public PowerUp power;
    public bool hasPowerup;
    public bool hasWhiteBrick;

    public Image imageWhiteBrick;
    public Image imagePowerupSpeed;
    public Image imagePowerupAttack;
    public Image imagePowerupReverse;
    public Image imagePowerupShield;

    public bool hasShield;
    public ParticleSystem psShield;
    private ParticleSystem psSpeed;
    public GameObject myVFX;
    public AudioSource audioShield;
    private ParticleSystem.EmissionModule emmision;
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
        hasPowerup = false;
        hasWhiteBrick = false;
        imageWhiteBrick.enabled = false;
        imagePowerupSpeed.enabled = false;
        imagePowerupAttack.enabled = false;
        imagePowerupReverse.enabled = false;
        imagePowerupShield.enabled = false;

        var shield = transform.Find("ShieldSoftBlue");
        var speed = transform.Find("MagicChargeBlue");
        psShield = shield.GetComponent<ParticleSystem>();
        audioShield = shield.GetComponent<AudioSource>();
        emmision = psShield.emission;
        psSpeed = speed.GetComponent<ParticleSystem>();
    }

    public void StartShield()
    {
        psShield.Play();        
        emmision.enabled = true;
        audioShield.Play();
    }

    public void StopShield()
    {
        emmision.enabled = false;
        psShield.Stop();
    }

    public void StartSpeed()
    {
        psSpeed.Play();
    }

    public void StopSpeed()
    {
        psSpeed.Stop();
    }

    public IEnumerator SlowRemoveShield()
    {
        yield return new WaitForSeconds(1);
        hasShield = false;
    }

    public void CountRound()
    {
        rounds += 1;
        if(rounds < 4)
        {
            textRounds.text = "Round: " + rounds + "/3";
        } else
        {
            textRounds.text = "You finished!";
        }
    }

    public void UsedPowerup()
    {
        hasPowerup = false;
        power = null;
        //textPowerup.text = "Powerup: ";
        hasWhiteBrick = false;
        imageWhiteBrick.enabled = false;

        imagePowerupSpeed.enabled = false;
        imagePowerupAttack.enabled = false;
        imagePowerupReverse.enabled = false;
        imagePowerupShield.enabled = false;
}

    public float GetDistance()
    {
        //Debug.Log((transform.position + lastZone.position).magnitude);
        return (transform.position + lastZone.position).magnitude + CurrentZone * WAYPOINT_VALUE + rounds * LAP_VALUE;
    }

    public int GetKartPosition(List<Transform> carTransformList)
    {
        float distance = GetDistance();
        int position = 1;
        //Debug.Log("Distance Cart: " + distance);
        foreach (Transform car in carTransformList)
        {
            PlayerStats thePlayer = car.GetComponent<PlayerStats>();
            if (thePlayer.GetDistance() > distance)
            {
                position++;
            }
        }
        //Debug.Log("Position: " + position);
        textPosition.text = "Position: " + position + "/4";
        return position;
    }
}
