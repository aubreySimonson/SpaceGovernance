using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStars : MonoBehaviour
{
    public int numStars;
    public GameObject star;

    public float minDistance;
    public float maxDistance;
    public float minSpeed;
    public float maxSpeed;

    public void Generate() {
        for (int i = 0; i < numStars; i++) {
            float speed = Random.Range(minSpeed, maxSpeed);
            float radius = Random.Range(minDistance, maxDistance);
            float theta = Random.Range(0f, 2*Mathf.PI);
            float phi = Random.Range(0f, 2*Mathf.PI);

            float x = transform.position.x + radius * Mathf.Sin(phi) * Mathf.Cos(theta);
            float y = transform.position.y + radius * Mathf.Sin(phi) * Mathf.Sin(theta);
            float z = transform.position.z + radius * Mathf.Cos(phi);

            Vector3 direction = new Vector3(0, 0, 1);
            GameObject newStar = Instantiate(star, new Vector3(x, y, z), Quaternion.identity);
            newStar.GetComponent<Translation>().speed = speed;
            newStar.GetComponent<Translation>().direction = direction;
        }
    }
}
