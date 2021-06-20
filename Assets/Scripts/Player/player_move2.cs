using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move2 : MonoBehaviour
{
    public float _force, _maxSpeed;
    public float jetpackForce;
    public double jetpackFuel = 300;

    public Transform groundCheck;
    public float groundDistance;
    private bool isGrounded;
    public LayerMask ground;
 
    [SerializeField]
    private float _currentSpeed, z, x;
 
    private Vector3 _direction;
    private Rigidbody _rBody;

 
    void Start()
    {
        _direction = Vector3.zero;
        _rBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void FixedUpdate()
    {
        //For Debugging
        _currentSpeed = _rBody.velocity.magnitude;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if (_currentSpeed < 0)
        {
            _currentSpeed = 0;
        }

        while(isGrounded && jetpackFuel <= 300)
        {
            jetpackFuel += 1;
        }


        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
 
        if (x != 0 || z != 0)
        {
            _direction = transform.right * x + transform.forward * z;
            _direction.Normalize();
 
            _rBody.AddForce(_direction * _force, ForceMode.Acceleration);
            
        }

        if (Input.GetMouseButton(1) && jetpackFuel > 0)
        {
            _rBody.AddForce(Vector3.up * jetpackForce, ForceMode.Acceleration);
            jetpackFuel -= 2;
        }
    }
}
