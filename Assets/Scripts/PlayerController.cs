using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 4f, sprintSpeed = 12f, rotationSpeed = 5f, jumpForce = 5f, gravity = -40f;

    [Header("References")]
    private CharacterController characterController;

    [Header("Vars")]
    [SerializeField] private Transform orientation;
    private float rotation;
    private Vector3 newPos;
    private float vertVelocity;
    private float currSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currSpeed = walkSpeed;
    }

    public void MovePlayer(Vector2 moveVector)
    {
        newPos = orientation.forward * moveVector.y + orientation.right * moveVector.x;

        newPos = newPos * Time.deltaTime * currSpeed;
        characterController.Move(newPos);

        vertVelocity = vertVelocity + gravity * Time.deltaTime;
        characterController.Move(new Vector3(0, vertVelocity, 0) * Time.deltaTime);
    }

    public void RotatePlayer(Vector2 rotationVector)
    {
        rotation += rotationVector.x * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            vertVelocity = jumpForce;
        }
    }

    public void Sprint(bool isSprinting)
    {
        if (isSprinting)
        {
            currSpeed = sprintSpeed;
        } else
        {
            currSpeed = walkSpeed;
        }
    }
}
