using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 3f;

    [Header("References")]
    private CharacterController characterController;

    [Header("Input")]
    private float hInput;
    private float vInput;

    [Header("Vars")]
    [SerializeField] private Transform orientation;
    private Vector3 newPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateInput();
        UpdateMovement();
    }

    void UpdateMovement()
    {
        newPos = orientation.forward * vInput + orientation.right * hInput;
        characterController.Move(newPos * Time.deltaTime * walkSpeed);
    }

    private void UpdateInput()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }
}
