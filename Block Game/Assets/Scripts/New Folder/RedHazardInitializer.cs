using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHazardInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in transform)
        {
            t.tag = "Hazard:Blue,Green";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
