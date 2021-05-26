using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    TextMesh hpTextMesh;
    public string playerName;
    public Image healthStatus;

    // Start is called before the first frame update
    void Start()
    {
        hpTextMesh = gameObject.GetComponent<TextMesh>();
        healthStatus = transform.parent.Find("HpBar/Foreground").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform.parent.transform.parent.transform.parent;
        PlayerProperties player = playerTransform.Find("LegoPaperScissors").GetComponent<PlayerProperties>();
        hpTextMesh.text = $"{player.playerName}\n{player.currentHp}/{player.maxHp}\n";
        healthStatus.fillAmount = player.currentHp / player.maxHp;
    }
}
