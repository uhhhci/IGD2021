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
        int[] multiplierThresholds;

        public Text scoreText;

        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            multiplier = 1;
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
            score += multiplier * (int)points;
        }

        public void NormalHit()
        {
            Hit(HitQuality.NORMAL);
        }

        public void GoodHit()
        {
            Hit(HitQuality.GOOD);
        }

        public void PerfectHit()
        {
            Hit(HitQuality.PERFECT);
        }

        public void Missed()
        {
            Debug.Log("Missed");
            score -= 0; // Do we want Minus-Points?
            multiplier = 1;
            hitStreak = 0;
        }
    }
}