//unclear where this is used?  It might be a predecessor to Orbit.cs which is no longer used.--followspotfour@gmail.com (formerly asimonso@mit.edu)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
