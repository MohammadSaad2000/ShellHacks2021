using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StoryManager : MonoBehaviour
{
    public GameObject whiteLightInner;
    public GameObject redLight;
    public GameObject blueLight;
    public GameObject greenLight;

    public AudioSource whiteSrc;
    public AudioSource redSrc;
    public AudioSource blueSrc;
    public AudioSource greenSrc;

    public GameObject winScreen;

    [HideInInspector] public static int checkPointNumber = 0;
    
    private bool hasRed = false;
    private bool hasBlue = false;
    private bool hasGreen = false;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientIntensity = 0.85f;
        whiteLightInner.SetActive(true);
        redLight.SetActive(false);
        blueLight.SetActive(false);
        greenLight.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("StoryEffect1"))
        {
            if(hasRed && hasGreen && hasBlue)
            {
                whiteSrc.enabled = true;
                whiteLightInner.SetActive(true);
                for (int i = 1; i <= 6; i++)
                {
                    MaterialManager.mainInstance.changeSideMaterial("Side" + i, MaterialManager.mainInstance.gray);
                }
                winScreen.SetActive(true);
                RenderSettings.ambientIntensity = 3.0f;
                InputManager.controls.Movement.Disable();
            } else
            {
                whiteSrc.enabled = false;
                whiteLightInner.SetActive(false);
                redLight.SetActive(!hasRed);
                blueLight.SetActive(!hasBlue);
                greenLight.SetActive(!hasGreen);
                checkPointNumber = 1;
            }

        } else if (other.tag.Equals("StoryEffect2"))
        {
            redLight.SetActive(false);
            MaterialManager.mainInstance.changeSideMaterial("Side1", MaterialManager.mainInstance.red);
            MaterialManager.mainInstance.changeSideMaterial("Side6", MaterialManager.mainInstance.red);
            hasRed = true;
            checkPointNumber = 2;
        }
        else if (other.tag.Equals("StoryEffect3"))
        {
            blueLight.SetActive(false);
            MaterialManager.mainInstance.changeSideMaterial("Side2", MaterialManager.mainInstance.blue);
            MaterialManager.mainInstance.changeSideMaterial("Side4", MaterialManager.mainInstance.blue);
            hasBlue = true;
            checkPointNumber = 3;
        }
        else if (other.tag.Equals("StoryEffect4"))
        {
            greenLight.SetActive(false);
            MaterialManager.mainInstance.changeSideMaterial("Side3", MaterialManager.mainInstance.green);
            MaterialManager.mainInstance.changeSideMaterial("Side5", MaterialManager.mainInstance.green);
            hasGreen = true;
            checkPointNumber = 4;
        }

    }
}
