/// <summary>
/// Part of Immersive Space Governance Project
/// Prevents WebVR Camera from leaving the spacecraft
/// We should be able to do that using rigidbodys and colliders, but for some reason that isn't working with this camera
/// So this is our hack solution.
/// It will definitely hurt our performance, and we should replace it with rigidbodys and colliders for the VR version.
/// 
/// Will fail if we start the game with the player out of bounds
/// ???--->asimonso@mit.edu
///Last edited May 2021
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSystem : MonoBehaviour
{
    public float maxX, minX, maxY, minY, maxZ, minZ;//boundaries
    private Vector3 lastLegalPosition;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localPosition.x >= maxX)
        {
            gameObject.transform.localPosition = lastLegalPosition;
        }
        else if (gameObject.transform.localPosition.x <= minX)
        {
            gameObject.transform.localPosition = lastLegalPosition;
        }
        else if (gameObject.transform.localPosition.y >= maxY)
        {
            gameObject.transform.localPosition = lastLegalPosition;
        }
        else if (gameObject.transform.localPosition.y <= minY)
        {
            gameObject.transform.localPosition = lastLegalPosition;
        }
        else if (gameObject.transform.localPosition.z >= maxZ)
        {
            gameObject.transform.localPosition = lastLegalPosition;
        }
        else if (gameObject.transform.localPosition.z <= minZ)
        {
            gameObject.transform.localPosition = lastLegalPosition;
        }
        else
        {
            lastLegalPosition = gameObject.transform.localPosition;
        }

    }
}
