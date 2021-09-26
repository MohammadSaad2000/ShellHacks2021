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

    private bool hasRed = false;
    private bool hasBlue = false;
    private bool hasGreen = false;

    // Start is called before the first frame update
    void Start()
    {
        whiteLightInner.SetActive(true);
        redLight.SetActive(false);
        blueLight.SetActive(false);
        greenLight.SetActive(false);
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
            } else
            {
                whiteSrc.enabled = false;
                whiteLightInner.SetActive(false);
                redLight.SetActive(true);
                blueLight.SetActive(true);
                greenLight.SetActive(true);
            }

        } else if (other.tag.Equals("StoryEffect2"))
        {
            redLight.SetActive(false);
            MaterialManager.mainInstance.changeSideMaterial("Side 1", MaterialManager.mainInstance.red);
            MaterialManager.mainInstance.changeSideMaterial("Side 6", MaterialManager.mainInstance.red);
            hasRed = true;
        }
        else if (other.tag.Equals("StoryEffect3"))
        {
            redLight.SetActive(false);
            MaterialManager.mainInstance.changeSideMaterial("Side 2", MaterialManager.mainInstance.blue);
            MaterialManager.mainInstance.changeSideMaterial("Side 4", MaterialManager.mainInstance.blue);
            hasBlue = true;
        }
        else if (other.tag.Equals("StoryEffect4"))
        {
            redLight.SetActive(false);
            MaterialManager.mainInstance.changeSideMaterial("Side 3", MaterialManager.mainInstance.green);
            MaterialManager.mainInstance.changeSideMaterial("Side 5", MaterialManager.mainInstance.green);
            hasGreen = true;
        }

    }
}
