/// <summary>
/// Part of Immersive Space Governance Project
/// Controls the slow blinking of all lights in the spacecraft.  
/// Works very closely with door open.
/// 
/// ???--->asimonso@mit.edu (now followspotfour@gmail.com)
///Last edited July 2021
/// </summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{

    private float changeStart;
    private float changeEnd;
    private bool turningOn;
    private bool turningOff;
    private bool lightOn;
    private Material lightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        lightMaterial = GetComponent<Renderer>().material;
        lightMaterial.SetColor("_EmissionColor", Color.black);
        turningOn = false;
        turningOff = false;
        lightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (turningOn) {
            if (currentTime > changeEnd){
                // light is completely on
                turningOn = false;
                lightOn = true;
            } else {
                Color newColor = Color.Lerp(Color.black, Color.white, (currentTime - changeStart)/(changeEnd - changeStart));
                lightMaterial.SetColor("_EmissionColor", newColor);
            }
        } else if (turningOff){
            if (currentTime > changeEnd){
                // light is completely off
                turningOff = false;
                lightOn = false;
            } else {
                Color newColor = Color.Lerp(Color.white, Color.black, (currentTime - changeStart)/(changeEnd - changeStart));
                lightMaterial.SetColor("_EmissionColor", newColor);
            }
        }
    }

    public void TurnOn(float changeDuration) {
        if (!(lightOn || turningOn || turningOff)){
            // turn on light only if it is currently off
            turningOn = true;
            changeStart = Time.time;
            changeEnd = changeStart + changeDuration;
        }
    }

    public void TurnOff(float changeDuration) {
        if (!(!lightOn || turningOff || turningOn)) {
            // turn off light only if it is currently on
            turningOff = true;
            changeStart = Time.time;
            changeEnd = changeStart + changeDuration;
        }
    }
}
