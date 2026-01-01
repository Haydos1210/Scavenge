using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("CamSettings")]
    private float sensX = 1f;
    private float sensY = 1f;

    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CamController camController;
    private PlayerControls playerControls;

    [Header("Vars")]
    private InputAction move, sprint, jump, look;
    private bool isSprinting;
    private float rotationX;
    private float rotationY;
    void Awake()
    {
        playerControls = new PlayerControls();

        //move = InputSystem.actions.FindAction("Move");
        //look = InputSystem.actions.FindAction("Look");
        //jump = InputSystem.actions.FindAction("Jump");
        //sprint = InputSystem.actions.FindAction("Sprint");
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        look = playerControls.Player.Look;
        look.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += OnJumpPerformed;

        sprint = playerControls.Player.Sprint;
        sprint.Enable();
        sprint.started += ctx => SetSprinting(true);
        sprint.canceled += ctx => SetSprinting(false);
    }

    void OnDisable()
    {
        move.Disable();
        look.Disable();
        jump.Disable();
        sprint.Disable();
    }

    private void SetSprinting(bool value)
    {
        isSprinting = value;
        //Debug.Log("Sprinting: " + isSprinting);
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        playerController.Jump();
    }

    //private void StartSprint(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Sprinting");
    //    isSprinting = true;
    //}

    //private void CancelSprint(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Not Sprinting");
    //    isSprinting = false;
    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sprint.IsPressed());
        //if (Keyboard.current.leftShiftKey.wasReleasedThisFrame) Debug.Log("Shift released");
        //Debug.Log(Keyboard.current.leftShiftKey.isPressed);

        //bool isSprinting = sprint.ReadValue<float>() > 0f ? true : false;
        Vector2 moveInput = move.ReadValue<Vector2>();
        playerController.MovePlayer(moveInput, isSprinting);
        HandleCamera();

        
    }

    void HandleCamera()
    {
        Vector2 lookInput = look.ReadValue<Vector2>();
        playerController.RotatePlayer(lookInput);
        rotationY += lookInput.x * sensX;
        rotationX -= lookInput.y * sensY;
        
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        camController.RotateCamera(rotationX, rotationY);
    }
}
