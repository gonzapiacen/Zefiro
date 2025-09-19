using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Playermove : MonoBehaviour
{
    public static Playermove instance;


    [Header("Movement")]
    public float walkSpeed = 5f;
    public bool enableTranslation = true;
    public float gravity = -9.81f;
    public float jumpForce = 7f;
    public int maxJumps = 2;

    [Header("Look")]
    public float mouseSensitivity = 2f;
    public bool rotateWithMouse = true;
    public Transform cameraTransform;

    [Header("Camera Follow")]
    public Vector3 cameraOffset = new Vector3(0.6f, 1.6f, -2f);
    public float cameraSmoothTime = 0.05f;

    private CharacterController controller;
    private float pitch = 0f;
    private float yaw = 0f;
    private Vector3 cameraVelocity = Vector3.zero;

    private int jumpCount = 0;
    [HideInInspector] public float verticalVelocity = 0f;



    private void Awake()
    {
        instance = this;
    }

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        yaw = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleLook();
        HandleMove();
    }

    void LateUpdate()
    {
        HandleCameraFollow();
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        if (rotateWithMouse)
        {
            transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        }

        if (cameraTransform != null)
            cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    void HandleMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 camForward = cameraTransform != null ? cameraTransform.forward : transform.forward;
        Vector3 camRight = cameraTransform != null ? cameraTransform.right : transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = camForward * v + camRight * h;
        if (move.sqrMagnitude > 1f) move.Normalize();

        bool grounded = controller.isGrounded;
        if (grounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            verticalVelocity = jumpForce;
            jumpCount++;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * walkSpeed;
        velocity.y = verticalVelocity;

        if (enableTranslation)
            controller.Move(velocity * Time.deltaTime);
        else
            controller.Move(new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
    }

    void HandleCameraFollow()
    {
        if (cameraTransform == null) return;

        Vector3 targetPos = transform.position + Quaternion.Euler(0f, yaw, 0f) * cameraOffset;
        if (cameraSmoothTime > 0f)
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPos, ref cameraVelocity, cameraSmoothTime);
        else
            cameraTransform.position = targetPos;
    }
}
