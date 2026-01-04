using System;
using UnityEngine;

public class CamController : MonoBehaviour
{

    [Header("Vars")]
    [SerializeField] private GameObject orientationObj;

    internal void RotateCamera(float rotationX, float rotationY)
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientationObj.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
