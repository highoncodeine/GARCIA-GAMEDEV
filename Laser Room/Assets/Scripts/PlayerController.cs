using UnityEngine;
using UnityEngine.InputSystem;
    
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.5f;
    [SerializeField] private float runSpeed = 9.0f;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float fallThreshold = -50.0f;

    private Camera mainCamera;
    private CharacterController characterController;
    private InputAction moveInput;
    private InputAction runInput;
    private InputAction jumpInput;

    private float currentMoveSpeed = 0.0f;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = GetComponentInChildren<Camera>();
        
        moveInput = InputSystem.actions.FindAction("Move");
        runInput = InputSystem.actions.FindAction("Sprint");
        jumpInput = InputSystem.actions.FindAction("Jump");
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        checkIfOutOfBounds();
        Vector2 moveVector =  moveInput.ReadValue<Vector2>();
        HandleMovement(moveVector);
    }

    private void HandleMovement(Vector2 moveVector)
    {
        // check if run button is being held
        currentMoveSpeed = runInput.IsPressed() ? runSpeed : moveSpeed;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        float currentY = moveDirection.y;
        
        moveDirection = (forward * (moveVector.y * currentMoveSpeed) + right * (moveVector.x * currentMoveSpeed));
        HandleJump(currentY);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HandleJump(float currentY)
    {
        if (characterController.isGrounded)
        {
            if (jumpInput.WasPressedThisFrame())
            {
                moveDirection.y = jumpForce;
            }
            else
            {
                moveDirection.y = -2f;
            }
        }
        else
        {
            moveDirection.y = currentY - (gravity * Time.deltaTime);
        }
    }
    
    private void checkIfOutOfBounds()
    {
        if (transform.position.y < fallThreshold)
        {
            characterController.enabled = false;
            transform.position = new Vector3(0.0f,5f,0f);
            moveDirection.y = 0f;
            characterController.enabled = true;
        }
    }
}
