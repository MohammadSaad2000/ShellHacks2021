using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    InputMaster controls;
    Rigidbody rigidbody;

    public Transform cameraTarget;
    public Vector3 cameraOffset;
    public float rollSpeed = 3.0f;
    public ParticleSystem normalImpact;
    

    private bool isMoving = false;
    private bool isGrounded = true;

    // Start is called before the first frame update
    private void Start()
    {
        controls = InputManager.controls;
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        checkisGrounded();

        if (!isGrounded) return;
        if (isMoving) return;

        checkFaceDownSide();

        Vector3 direction = controls.Movement.Move.ReadValue<Vector2>();
        direction.z = direction.y;
        direction.y = 0;

        if (direction.sqrMagnitude == 1)
        {
            var pivot = transform.position + (Vector3.down + direction) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, direction);
            StartCoroutine(Roll(pivot, axis));
        }

    }

    void checkisGrounded()
    {
        RaycastHit hit;
        int layerMask = (1 << 3) | (1 << 7);
        //Debug.DrawRay(transform.position, Vector3.down * 1);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, layerMask);
        //Debug.Log("Grounded: " + isGrounded);
        if (isGrounded)
        {
            cameraTarget.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z) + cameraOffset;
        } else
        {
            cameraTarget.position = transform.position + cameraOffset;
        }

        if (!isGrounded)
        {
            rigidbody.isKinematic = false;
        }
       
    }

    public void checkFaceDownSide() {

        RaycastHit hit;
        int layerMask = 1 << 6;
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z), Vector3.up * 10);
        string faceDownSideName;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z), Vector3.up, out hit, 1.0f, layerMask))
        {
            faceDownSideName = hit.collider.name;
        }

        layerMask = 1 << 7;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, layerMask))
        {
            if (hit.collider.tag.Equals("Hazard"))
            {
                Debug.LogWarning("You Lost!");
            }


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
