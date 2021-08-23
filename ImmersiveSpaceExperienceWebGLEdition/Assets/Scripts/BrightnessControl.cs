/// <summary>
/// Part of Immersive Space Governance Project which frankly could use a snappier name
/// 
/// Controls brightness of one light
/// ???--->asimonso@mit.edu
///Last edited June 2021
/// </summary>
/// 
/// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessControl : MonoBehaviour
{
    public Light thisLight;
    public float bright, dark, fadeCounter, fadeTime;
    public bool fadeUp;//are we fading up or down?
    // Start is called before the first frame update
    void Start()
    {
        thisLight = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeCounter >= fadeTime)
        {
            fadeUp = false;
        }
        if (fadeCounter <= 0)
        {
            fadeCounter = 0.001f;//avoid divide by 0
            fadeUp = true;
        }
        if (fadeUp)
        {
            thisLight.intensity = Mathf.Lerp(dark, bright, fadeCounter / fadeTime);
            fadeCounter++;
        }
        else
        {
            thisLight.intensity = Mathf.Lerp(dark, bright, fadeCounter / fadeTime);
            fadeCounter--;
        }
    }
}
