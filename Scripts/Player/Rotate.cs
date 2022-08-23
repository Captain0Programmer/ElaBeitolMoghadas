using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Sensitivity = 80f;
    public Transform PlayerBody;
    float YMouseRotation = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*Sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*Sensitivity*Time.deltaTime;
        YMouseRotation -= mouseY;
        YMouseRotation = Mathf.Clamp(YMouseRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(YMouseRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * mouseX);
    

    }
}
