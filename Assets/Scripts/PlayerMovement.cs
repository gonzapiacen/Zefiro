using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _speed = 6f;

    [Header("Jumping")]
    [SerializeField] int _jumpCount;
    [SerializeField] float _jumpForce;
    private Vector3 _movement;
    private Rigidbody _playerRigidbody;
    private float _horz = 0f;
    private float _vert = 0f;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _speed = 30f;
        _jumpCount = 2;
        _jumpForce = 5f;
    }

    void Update()
    {
        _horz = Input.GetAxis("Horizontal");
        _vert = Input.GetAxis("Vertical");

        Move();
        Jump();
    }

    void LateUpdate()
    {
        Turning();
    }

    public void Move()
    {
        Run();
        _movement.Set(_horz, 0f, _vert);

        //multiply with rotation to move in the faced direction
        _movement = transform.rotation * _movement.normalized * _speed * Time.deltaTime;

        //apply the movement via RigidBody
        _playerRigidbody.MovePosition(transform.position + _movement);
    }

    private void Run()
    {
        _speed = Input.GetKey(KeyCode.LeftShift) ? 50f : 30f;
    }

    public void Turning()
    {
        Quaternion currentRotation = transform.rotation;

        float cameraY = Camera.main.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, cameraY, currentRotation.eulerAngles.z);
    }

    public void Jump()
    {
        if (_jumpCount > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpCount--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _jumpCount = 2;
        }
    }
}
