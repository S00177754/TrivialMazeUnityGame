using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    public float SensitivitySpeed = 80f;
    public Transform playerTransform;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Move up into variables?
        float MouseX_Axis = Input.GetAxis("Mouse X") * SensitivitySpeed * Time.deltaTime;
        float MouseY_Axis = Input.GetAxis("Mouse Y") * SensitivitySpeed * Time.deltaTime;

        xRotation -= MouseY_Axis; //Addinbg to it gives opposite direction

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Clamp to 90 deg

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //applies rotation in order of z,x,y

        playerTransform.Rotate(Vector3.up * MouseX_Axis);
    }
}
