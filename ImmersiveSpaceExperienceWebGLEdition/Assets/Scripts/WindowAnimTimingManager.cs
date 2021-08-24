/// <summary>
/// Part of Immersive Space Governance Project
/// Manages movement of window of main room.
/// ???--->asimonso@mit.edu (now followspotfour@gmail.com)
///Last edited March 2021
/// </summary>



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We'll need to make changes if we want the windows to be able to rotate

public class WindowAnimTimingManager : MonoBehaviour
{
    public GameObject LeftDoor, RightDoor;//objects to move
    private bool doorOpened;
    public float speed;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpened){
            //if(Time.time >= animStart && Time.time <= animEnd)
            //{
                //float fraction = (Time.time - animStart) / (animStart - animEnd)/-1.0f;
                //Debug.Log("fraction: " + fraction);
                //LeftDoor.transform.position = Vector3.Lerp(UpperWindowStartPose, UpperWindowEndPose.localPosition, fraction);
                //RightDoor.transform.position = Vector3.Lerp(LowerWindowStartPose, LowerWindowEndPose.localPosition, fraction);
                LeftDoor.transform.Translate(0, Time.deltaTime * speed, 0);
                RightDoor.transform.Translate(0, Time.deltaTime * speed, 0); ;
            //}
        }
    }

    public void OpenWindow(float windowSpeed) {
        if (!doorOpened){
            // Open the window only if it is currently closed
            doorOpened = true;
            StartCoroutine(StopOpening());
            //animStart = Time.time;
            //animEnd = animStart + windowTime;
        }
    }

    IEnumerator StopOpening() {
        yield return new WaitForSeconds(distance / speed);
        doorOpened = false;
    }
}
