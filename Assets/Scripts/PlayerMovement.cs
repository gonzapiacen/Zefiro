using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask _floorMask;
    [SerializeField] float _speed = 6f;
    Vector3 _movement;
    Rigidbody _playerRigidbody;

    private float _camRayLength = 100f;
    private float _horz = 0f;
    private float _vert = 0f;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        Turning();
    }


    void FixedUpdate()
    {
        _horz = Input.GetAxis("Horizontal");
        _vert = Input.GetAxis("Vertical");

        Move();
    }


    void Move()
    {
        _movement.Set(_horz, 0f, _vert);

        //multiply with rotation to move in the faced direction
        _movement = transform.rotation * _movement.normalized * _speed * Time.deltaTime;

        //apply the movement via RigidBody
        _playerRigidbody.MovePosition(transform.position + _movement);
    }

    void Turning()
    {
        Quaternion currentRotation = transform.rotation;

        float cameraY = Camera.main.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, cameraY, currentRotation.eulerAngles.z);
    }

}
