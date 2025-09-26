using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;              // The object the camera follows
    [SerializeField] float _smoothing = 0.5f;          // Position smoothing speed
    [SerializeField] float _rotationSpeed = 5f;      // Mouse sensitivity
    [SerializeField] float _verticalClamp = 80f;     // Clamp for vertical rotation

    private Vector3 _offset;               // Initial offset from target
    private float _yaw = 0f;               // Horizontal rotation
    private float _pitch = 0f;             // Vertical rotation

    void Awake()
    {
        _smoothing = 0.5f;
        _rotationSpeed = 5f;
        _verticalClamp = 80f;
        _offset = transform.position - _target.position;
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor for immersive control
    }

    void Update()
    {
        // Mouse inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Accumulate rotation values
        _yaw += mouseX * _rotationSpeed;
        _pitch -= mouseY * _rotationSpeed;
        _pitch = Mathf.Clamp(_pitch, -_verticalClamp, _verticalClamp);
        
    }

    void LateUpdate()
    {
        // Calculate rotation from pitch and yaw
        Quaternion rotation = Quaternion.Euler(0, _yaw, 0);

        // Apply rotation to offset
        Vector3 rotatedOffset = rotation * _offset;

        // Smoothly interpolate camera position
        Vector3 targetCamPos = _target.position + rotatedOffset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing);

        // Always look at the target + added hight so it doesn´t look at it´s feet
        transform.LookAt(_target.position + Vector3.up * 2);
    }
}
