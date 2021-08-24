/// <summary>
/// Part of Immersive Space Governance Project
/// 
/// Old and not being used for anything right now.  Maybe should delete?
/// 
/// ???--->asimonso@mit.edu
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private bool buttonPressed;
    private Material buttonMaterial;

    // Start is called before the first frame update
    void Start()
    {
        buttonMaterial = GetComponent<Renderer>().material;
        buttonMaterial.color = Color.green;
        buttonPressed = false;
    }

    void OnTriggerEnter(Collider target) {
        if (!buttonPressed){
            if (target.tag == Tags.HAND_TAG){ // hand pressed the button
                buttonPressed = true;
                buttonMaterial.color = Color.red;
                float windowTime = 30f;
                // button opens the window and turns off the light
                GameObject.Find("WindowAnimManager").GetComponent<WindowAnimTimingManager>().OpenWindow(windowTime);
                GameObject.Find("Light").GetComponent<LightControl>().TurnOff(windowTime);
            }
        }
    }
}
