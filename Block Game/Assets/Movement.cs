using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    InputMaster controls;

    public Transform cameraTarget;
    public Vector3 cameraOffset;
    public float rollSpeed = 3.0f;
    public ParticleSystem normalImpact;
    

    private bool isMoving = false;

    // Start is called before the first frame update
    private void Start()
    {
        controls = InputManager.controls;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTarget.position = transform.position + cameraOffset;
        if (isMoving) return;

        Vector3 direction = controls.Movement.Move.ReadValue<Vector2>();
        direction.z = direction.y;
        direction.y = 0;

        //Debug.Log(direction);
        //Debug.Log(direction.sqrMagnitude);
        //Debug.DrawRay(transform.position, direction * 10);

        if (direction.sqrMagnitude == 1)
        {
            var pivot = transform.position + (Vector3.down + direction) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, direction);
            StartCoroutine(Roll(pivot, axis));
        }


    }


    IEnumerator Roll(Vector3 pivot, Vector3 axis)
    {
        isMoving = true;
        
        for (int i = 0; i < 90 / rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        float xSnap = Mathf.Round(transform.position.x * 2) / 2;
        float ySnap = Mathf.Round(transform.position.y * 2) / 2;
        float zSnap = Mathf.Round(transform.position.z * 2) / 2;
        transform.position = new Vector3(xSnap, ySnap, zSnap);
        cameraTarget.position = transform.position + cameraOffset;

        normalImpact.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y - 0.5f, cameraTarget.position.z);
        normalImpact.Play();

        isMoving = false;
    }
}
