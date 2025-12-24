using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private PlayerControls playerControls;
    private InputAction move, sprint, jump, look;
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
    }

    void OnDisable()
    {
        move.Disable();
        look.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = move.ReadValue<Vector2>();
        playerController.MovePlayer(moveVector);

        Vector2 lookVector = look.ReadValue<Vector2>();
        playerController.RotatePlayer(lookVector);

        //bool isSprinting = sprint.ReadValue<float>() > 0.5f;
        //if (isSprinting)
        //{
        //    Debug.Log(sprint.activeControl);
        //    Debug.Log("Yes");
        //} else
        //{
        //    Debug.Log("No");
        //}
        //playerController.Sprint(isSprinting);
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        playerController.Jump();
    }
}
