using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRings : MonoBehaviour
{

    public GameObject wallPrefab;
    public double radius = 8.0;
    public int numberOfRings = 2;
    public float lengthOfBlock = 2;
    public float yLevel = 0;

    public
    // Start is called before the first frame update
    void Start()
    {
        for(int ring = 1; ring <= numberOfRings; ring++)
        {
            float circumference = (float)(Mathf.PI * 2 * radius * ring);
            int numberOfBlocks = Mathf.FloorToInt( circumference / lengthOfBlock);
            for(int block = 1; block <= numberOfBlocks; block++)
            {
                float currentAngle = 360 / numberOfBlocks * block;
                float currentRadius = (float)(radius * ring);
                Vector3 position = PointOnCircle(currentRadius, currentAngle);
                Instantiate(wallPrefab, position, Quaternion.Euler(0, 360-currentAngle, 0));
            }
        }
    }


    public Vector3 PointOnCircle(float radius, float angleInDegrees)
    {
        // Convert from degrees to radians via multiplication by PI/180        
        float x = (float)(radius * Mathf.Cos(angleInDegrees * Mathf.PI / 180F));
        float y = (float)(radius * Mathf.Sin(angleInDegrees * Mathf.PI / 180F));

        return new Vector3(x, yLevel, y);
    }

}
