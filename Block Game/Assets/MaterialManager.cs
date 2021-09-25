using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static Material gray;
    public static Material red;
    public static Material orange;
    public static Material yellow;
    public static Material green;
    public static Material blue;
    public static Material purple;

    MeshRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material = gray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeSideMaterial(string sideName, Material material)
    {
        Transform t = transform.Find(sideName);
        t.GetComponent<MeshRenderer>().material = material;
    }

}
