/// <summary>
/// Part of Immersive Space Governance Project which frankly could use a snappier name
/// Collider on door which tells window manager to open it when door is approached.
/// Also controls dimming of lights in the main space, switch to threat condition.
/// This could use some pretty aggressive refactoring.  
/// Everything related to the threat condition lives in this file right now, and it should be in its own file
/// The language across doors/windows could definitely be standardized...
/// 
/// ???--->asimonso@mit.edu
///Last edited August 2021
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public WindowAnimTimingManager windowManager;
    public Collider player;
    public float windowTime;//speed
    public DimLights dimLights;//are we actually using this?
    public bool threatCondition;//which version of the experiment is this
    private bool threatConditionHappening = false;//has the threat part of the threat condition been triggered?
    public float timeToThreat;//amount of time in seconds between door open and threat condition
    public float threatConditionDuration;
    private float doorOpenTime = 99999.9f;
    public AudioSource alarm, doorSound;
    private bool doorSoundHasPlayed = false;
    private bool threatLightingHasTriggered = false;
    public GameObject satelight;
    private Color normalLighting;
    public Light[] lightsToChange;
    public GameObject[] lightCasingsToChange;//these are emissive
    public BrightnessControl[] brightnessControls;//these are emissive
    public Material normalColor;
    public Color normalEmissionColor;
    public float normalLightIntensity, threatLightIntensity, normalFadeTime, threatFadeTime;
    public float lightChangeDuration;//how long does it take the blue lights to turn red?
    public AudioSource welcomeVO1, welcomeVO2, threatVO;
    public bool shouldPlayWelcomeVO2, welcomeHasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        satelight.SetActive(false);
        normalLighting = lightsToChange[0].color;
        normalLightIntensity = lightsToChange[0].intensity;
        normalFadeTime = brightnessControls[0].fadeTime;
        lightCasingsToChange[0].GetComponent<Renderer>().material.EnableKeyword("EMISSION");
        normalColor = lightCasingsToChange[0].GetComponent<Renderer>().material;
        normalEmissionColor = lightCasingsToChange[0].GetComponent<Renderer>().material.GetColor("_EmissionColor");
        if (windowTime == 0.0f)
        {
            windowTime = 30f;
        }
    }

    private void Update()
    {
        if (shouldPlayWelcomeVO2 && !welcomeVO2.isPlaying && !welcomeVO1.isPlaying)//has the door opened, as are we done playing VO pt 1?
        {
            welcomeVO2.Play(0);
            shouldPlayWelcomeVO2 = false;
        }
        //the following if statement checks if this is the version with the threat condition, and if we're at the right point in time to be doing threat conditions things
        if (threatCondition && Time.time >= doorOpenTime + timeToThreat && !threatConditionHappening && !(Time.time >= doorOpenTime + timeToThreat + threatConditionDuration))
        {
            //change lighting
            float t = Mathf.PingPong(Time.time, lightChangeDuration) / lightChangeDuration;
            foreach(Light individualLight in lightsToChange)
            {
                individualLight.color = Color.Lerp(Color.black, Color.red, t);
                individualLight.intensity = Mathf.Lerp(normalLightIntensity, threatLightIntensity, t);
            }
            foreach (GameObject individualLightCasing in lightCasingsToChange)
            {
                individualLightCasing.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, Color.red, t);
                individualLightCasing.GetComponent<Renderer>().material.SetColor("_EmissionColor",Color.Lerp(normalColor.color, Color.red, t));
            }
            //it would be cool if you also killed the other lights, but maybe move the threat condition to a different script before you do that
            //start audio, other stuff that should only trigger once
            if (!alarm.isPlaying)
            {
                alarm.Play(0);
            }
            if (!welcomeVO2.isPlaying && !threatVO.isPlaying)
            {
                threatVO.Play(0);
            }
            //start satelight motion
            satelight.SetActive(true);
        }
        //checks if it is time to stop doing the threat condition
        if(Time.time >= doorOpenTime +timeToThreat + threatConditionDuration)
        {
            //don't set threatConditionHappening back to false, because it will immediately start again
            //return lighting
            foreach (Light individualLight in lightsToChange)
            {
                individualLight.color = normalLighting;
                individualLight.intensity = normalLightIntensity;
            }
            foreach (GameObject individualLightCasing in lightCasingsToChange)
            {
                individualLightCasing.GetComponent<Renderer>().material = normalColor;
                individualLightCasing.GetComponent<Renderer>().material.SetColor("_EmissionColor", normalEmissionColor);
            }
            //stop audio
            alarm.Pause();
            threatVO.Pause();
            //yeet satelight from existence
            satelight.SetActive(false);
        }
    }

    //the following function is really the only one that should stay in this script
    void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            Debug.Log("Object intersected is player");
            windowManager.OpenWindow(windowTime);
            dimLights.Dim();
            if (!threatLightingHasTriggered)
            {
                doorOpenTime = Time.time;
                threatLightingHasTriggered = true;
            }
            if (!welcomeHasTriggered && !welcomeVO1.isPlaying)
            {
                welcomeVO2.Play(0);
                welcomeHasTriggered = true;
            }
            if(!welcomeHasTriggered && welcomeVO1.isPlaying)
            {
                Debug.Log("We are now waiting to play VO2");
                shouldPlayWelcomeVO2 = true;
                welcomeHasTriggered = true;
            }
            if (!doorSoundHasPlayed)
            {
                doorSound.Play(0);
                doorSoundHasPlayed = true;
            }
        }
    }
}
