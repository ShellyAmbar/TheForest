using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooks : MonoBehaviour {

    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float MouseSensitivity;
    [SerializeField] private Transform PlayerBody;
    private float XAxisClamp;

    private void Awake() { LockCursor(); }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        XAxisClamp = 0.0f;
    }

    private void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        float MouseX = Input.GetAxis(mouseXInputName) * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis(mouseYInputName) * MouseSensitivity * Time.deltaTime;

        XAxisClamp += MouseY;
        if (XAxisClamp > 90.0f)
        {
            XAxisClamp = 90.0f;
            MouseY = 0.0f;
            ClampAxisRotationToValu(270.0f);
        }
        else if (XAxisClamp < -90.0f)
        {
            XAxisClamp = -90.0f;
            MouseY = 0.0f;
            ClampAxisRotationToValu(90.0f);
        }
        transform.Rotate(Vector3.left * MouseY);
        PlayerBody.Rotate(Vector3.up * MouseX);


    }
    private void ClampAxisRotationToValu(float Valu)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = Valu;
        transform.eulerAngles = eulerRotation;
    }
}
