using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _inputs = Vector3.zero;
    public Transform _groundCheck;
    private bool _isGrounded = true;


    public float speed = 5f;
    public float jumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float jetpackSpeed = 0.5f;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, GroundDistance, ground);
        
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        if (_inputs != Vector3.zero)
        {
            transform.forward = _inputs;
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    void fixedUpdate()
    {
        _rb.MovePosition(_rb.position + _inputs * speed * Time.deltaTime);
    }
}
