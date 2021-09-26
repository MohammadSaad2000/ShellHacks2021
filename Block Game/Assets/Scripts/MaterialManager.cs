using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material gray;
    public Material red;
    public Material green;
    public Material blue;

    [HideInInspector] public static MaterialManager mainInstance = null;

    MeshRenderer renderer;

    private void Awake()
    {
        if (mainInstance != null && mainInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mainInstance = this;
        }
    }

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

    public void changeSideMaterial(string sideName, Material material)
    {
        Transform t = transform.Find(sideName);
        t.GetComponent<MeshRenderer>().material = material;
    }

}
