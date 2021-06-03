using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GroupP
{
    public class Score : MonoBehaviour
    {
        public int score;
        public int hitStreak;
        public int multiplier;
        public int specialMultiplier;
        int[] multiplierThresholds;

        public GameObject hitEffect, goodEffect, perfectEffect, missedEffect;

        public Vector3 effectPosition = new Vector3(0f, 0f, 0f);
        public GameObject canvas;

        public Text scoreText;

        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            multiplier = 1;
            specialMultiplier = 0;
            hitStreak = 0;

            multiplierThresholds = new int[] { 3, 6, 9 };
            //InvokeRepeating("NormalHit", 1, 1); ----- (for testing)
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = score.ToString();
        }

        public void Hit(HitQuality points)
        {
            switch(points) {
                case HitQuality.NORMAL:
                    spawnEffect(hitEffect);
                    break;
                case HitQuality.GOOD:
                    spawnEffect(goodEffect);
                    break;
                case HitQuality.PERFECT:
                    spawnEffect(perfectEffect);
                    break;
            }
            hitStreak++;
            if (multiplier <= multiplierThresholds.Length && hitStreak >= multiplierThresholds[multiplier - 1])
            {
                multiplier++;
            }
            
            score += multiplier * (int)points + specialMultiplier * (int)points;
        }

        public void Missed()
        {
            spawnEffect(missedEffect);
            multiplier = 1;
            hitStreak = 0;
        }

        public void BadHit() {
            Debug.Log("Bad Hit");
            multiplier = 1;
            hitStreak = 0;
            score -= 10;
        }

        public void SpecialHit(HitQuality points) {
            Debug.Log("Special Hit");
            if (specialMultiplier <= multiplierThresholds.Length) {
                specialMultiplier++;
            }
            Hit(points);
        }

        public void spawnEffect(GameObject effectPrefab) {
            Debug.Log("spawned");
            GameObject effect = Instantiate(effectPrefab);
            
            effect.transform.SetParent(GameObject.Find("CanvasP").transform, false);
            effect.transform.localPosition = effectPosition;
            effect.transform.localScale = effectPrefab.transform.localScale;
            effect.SetActive(true);
        }
    }
}