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
            Debug.Log(points);
            hitStreak++;
            if (multiplier <= multiplierThresholds.Length && hitStreak >= multiplierThresholds[multiplier - 1])
            {
                multiplier++;
            }
            
            score += multiplier * (int)points + specialMultiplier * (int)points;
        }

        public void NormalHit()
        {
            Instantiate(hitEffect);
            Hit(HitQuality.NORMAL);
        }

        public void GoodHit()
        {
            Instantiate(goodEffect);
            Hit(HitQuality.GOOD);
        }

        public void PerfectHit()
        {
            Instantiate(perfectEffect);
            Hit(HitQuality.PERFECT);
        }

        public void Missed()
        {
            Instantiate(missedEffect);
            Debug.Log("Missed");
            score -= 0; // Do we want Minus-Points?
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
    }
}