using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;

    [Header("References")]
    private CharacterController characterController;

    [Header("Input")]
    private float hInput;
    private float vInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateMovement();
    }

    void UpdateMovement()
    {
        Vector3 newPos = new Vector3(hInput, 0, vInput);
        characterController.Move(newPos * Time.deltaTime * walkSpeed);
    }

    private void UpdateInput()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }
}
