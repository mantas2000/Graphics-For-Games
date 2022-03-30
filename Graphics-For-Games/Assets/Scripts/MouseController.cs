using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 200f;
    public Transform body;
    private float _xRotation;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Hide cursor from the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        // Get user's input
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        _xRotation -= mouseY;
        
        // Limit camera's rotation
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        // Move camera on Y scale
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        
        // Move camera on X scale
        body.Rotate(Vector3.up * mouseX);
    }
}
