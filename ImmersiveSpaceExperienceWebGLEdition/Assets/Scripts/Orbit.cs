/// <summary>
/// Part of Immersive Space Governance Project which frankly could use a snappier name
/// For making stuff rotate around other stuff
/// 
/// ???--->asimonso@mit.edu
///Last edited May 2021
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject orbits;//that which does the orbiting
    public GameObject isOrbited;
    public float speed;//number of degrees per second

    // Start is called before the first frame update
    void Start()
    {
        //error handling
        if(orbits == null)
        {
            Debug.LogErrorFormat("Object which orbits not set!");
        }
        if(isOrbited == null)
        {
            Debug.LogErrorFormat("Object whic is orbited not set!");
        }
        if(speed == 0.0f)
        {
            Debug.LogErrorFormat("speed not set.  Assuming default speed of 1");
            speed = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        orbits.transform.RotateAround(isOrbited.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
