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
    public float randomCapProb = 0.1f;
    public float offsetRotation = 5f, offsetRadius = 1f, offsetAngle = 5f, offsetHeight = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        for(int ring = 1; ring <= numberOfRings; ring++)
        {
            float circumference = (float)(Mathf.PI * 2 * radius * ring);
            int numberOfBlocks = Mathf.CeilToInt( circumference / lengthOfBlock);
            float currentRadius = (float)(radius * ring);
            for (int block = 1; block <= numberOfBlocks; block++)
            {
                if (Random.Range(0, 100) <= randomCapProb * 100) continue;
                float currentAngle = (360f / numberOfBlocks) * block;
                Vector3 position = PointOnCircle(currentRadius + Random.Range(-offsetRadius, offsetRadius), currentAngle + Random.Range(-offsetRotation, offsetRotation));
                //Debug.Log("currentAngle: " + currentAngle + "  numberOfBlocks: " + numberOfBlocks + "  block: " + block + "  xPos: " + position.x + "  yPos: " + position.y);
                Instantiate(wallPrefab, position, Quaternion.Euler(0, 360-currentAngle + Random.Range(-offsetAngle, offsetAngle), 0));
            }
        }
    }


    public Vector3 PointOnCircle(float radius, float angleInDegrees)
    {
        // Convert from degrees to radians via multiplication by PI/180        
        float x = (float)(radius * Mathf.Cos(angleInDegrees * Mathf.PI / 180F));
        float y = (float)(radius * Mathf.Sin(angleInDegrees * Mathf.PI / 180F));

        return new Vector3(x, yLevel + Random.Range(-offsetHeight, offsetHeight), y);
    }

}
