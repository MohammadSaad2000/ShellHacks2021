using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float speed = 100.0f;
    public float offset;
    private float rotY = 0.0f;

    InputMaster controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = InputManager.controls;        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = controls.Movement.Look.ReadValue<float>();
        Debug.Log(deltaX);
        rotY += deltaX * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, rotY + offset, transform.eulerAngles.z);
    }
}
