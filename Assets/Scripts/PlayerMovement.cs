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
    
    Ray _camRay;

    RaycastHit _floorHit;
    Vector3 _playerToMouse;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
            _horz = Input.GetAxis("Horizontal");
            _vert = Input.GetAxis("Vertical");

            Move();
            Turning();
    }


    void Move()
    {
        _movement.Set(_horz, 0f, _vert);

        _movement = _movement.normalized * _speed * Time.deltaTime;

        _playerRigidbody.MovePosition(transform.position + _movement);
    }

    void Turning()
    {
        _camRay = Camera.main.ScreenPointToRay(Input.mousePosition);



        Debug.DrawLine(_camRay.origin, _camRay.direction, Color.red);

        if (Physics.Raycast(_camRay, out _floorHit, _camRayLength, _floorMask))
        {
            _playerToMouse = _floorHit.point - transform.position;

            _playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(_playerToMouse, Vector3.up);

            _playerRigidbody.MoveRotation(newRotation);


        }
    }

}
