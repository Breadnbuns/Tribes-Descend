using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float _force, _maxSpeed;
    public float _jumpHeight;
 
    [SerializeField]
    private float _currentSpeed, z, x;
 
    private Vector3 _direction;
    private Rigidbody _rBody;

    private bool _isGrounded;
    public Transform _groundCheck;
    public float GroundDistance = 0.2f;
    public LayerMask ground;
 
    void Start()
    {
        _direction = Vector3.zero;
        _rBody = GetComponent<Rigidbody>();
        _isGrounded = true;
    }
 
    void FixedUpdate()
    {
        //For Debugging
        _currentSpeed = _rBody.velocity.magnitude;
        _isGrounded = Physics.CheckSphere(_groundCheck.position, GroundDistance, ground, QueryTriggerInteraction.Ignore);

        if (_currentSpeed < 0)
        {
            _currentSpeed = 0;
        }


        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
            _rBody.AddForce(Vector3.up * Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
 
        if (x != 0 || z != 0)
        {
            _direction = transform.right * x + transform.forward * z;
            _direction.Normalize();
 
            _rBody.AddForce(_direction * _force, ForceMode.Acceleration);
 
            if (_rBody.velocity.magnitude > _maxSpeed) 
            {
                _rBody.velocity = _rBody.velocity.normalized * _maxSpeed;
            }
        }
    }
}
