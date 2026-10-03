using UnityEngine;
using UnityEngine.InputSystem;
public class MouseLook : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float mouseSensitivity = 50f;
    [SerializeField] private Transform playerBody;

    private InputAction lookAction;
    private float xRotation = 0f;

    private void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 lookInput =  lookAction.ReadValue<Vector2>();
        
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
