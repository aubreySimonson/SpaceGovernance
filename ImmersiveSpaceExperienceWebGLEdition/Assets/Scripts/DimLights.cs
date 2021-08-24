/// <summary>
/// Part of Immersive Space Governance Project
/// 
/// Unclear if we're actually using this anywhere?
/// 
/// Turns the lights on or off on a lerp.
/// 
/// Door Open should call this
/// 
/// ???--->asimonso@mit.edu
///Last edited June 2021
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimLights : MonoBehaviour
{
    public Light[] lights;//you still have to load this manually sorry
    public float dark;
    public float bright;
    public float fadeTime;//in frames
    public float fadeCounter = 0.0f;
    public bool fadingUp;
    public bool fadingDown;

    private void Start()
    {
        foreach (Light light in lights)
        {
            light.intensity = 0.0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (fadingDown)
        {
            if (fadeCounter < fadeTime)
            {
                foreach (Light light in lights)
                {
                    light.intensity = Mathf.Lerp(dark, bright, fadeCounter / fadeTime);
                }
                fadeCounter++;
            }
        }
    }

    public void Dim()
    {
        fadeCounter = 0;
        fadingUp = false;
        fadingDown = true;
    }
}
