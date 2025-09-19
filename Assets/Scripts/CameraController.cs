using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;              // The object the camera follows
    [SerializeField] float smoothing = 5f;          // Position smoothing speed
    [SerializeField] float rotationSpeed = 5f;      // Mouse sensitivity
    [SerializeField] float verticalClamp = 80f;     // Clamp for vertical rotation

    private Vector3 offset;               // Initial offset from target
    private float yaw = 0f;               // Horizontal rotation
    private float pitch = 0f;             // Vertical rotation

    void Start()
    {
        offset = transform.position - target.position;
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor for immersive control
    }

    void Update()
    {
        // Mouse inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Accumulate rotation values
        yaw += mouseX * rotationSpeed;
        pitch -= mouseY * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -verticalClamp, verticalClamp);
    }

    void LateUpdate()
    {
        // Calculate rotation from pitch and yaw
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Apply rotation to offset
        Vector3 rotatedOffset = rotation * offset;

        // Smoothly interpolate camera position
        Vector3 targetCamPos = target.position + rotatedOffset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        // Always look at the target
        transform.LookAt(target.position);
    }

}
