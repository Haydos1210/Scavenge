using System;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("CamSettings")]
    private float sensX = 400;
    private float sensY = 400;

    [Header("Input")]
    private float mouseX;
    private float mouseY;

    [Header("Vars")]
    [SerializeField] private GameObject orientationObj;
    private float rotationX;
    private float rotationY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientationObj.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    void UpdateInput()
    {
        //mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        //mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
    }
}
