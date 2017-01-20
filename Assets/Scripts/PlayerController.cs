﻿using UnityEngine;
using XboxCtrlrInput;

[RequireComponent(typeof(SphereCollider), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _dashForce;

    [SerializeField] private XboxController _xboxController;

    [SerializeField] private string _playerName;

    private Vector3 _movementDirection;
    private Rigidbody _rigidbody;
    private bool _isDashActivated;
    private bool _isSphere;
    private BoxCollider _boxCollider;
    private SphereCollider _sphereCollider;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {

        //        XCI.DEBUG_LogControllerNames();
//        var isLoggedIn = XCI.IsPluggedIn((int)_xboxController);
//        Debug.LogFormat("Controller {0} is logged in: {1}", _xboxController, isLoggedIn );

//       Debug.Log(XCI.GetNumPluggedCtrlrs());
//        XCI.DEBUG_LogControllerNames();

        // Get inputs
        var horizontalInput = Input.GetAxisRaw("Horizontal" + _playerName);
        var verticalInput = Input.GetAxisRaw("Vertical" + _playerName);

        // Apply movement velocity
        _movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            _isDashActivated = true;
        }
    }

    private void TryActivateDash()
    {
        if (_isDashActivated)
        {
            _isDashActivated = false;
            var dashDirection = _movementDirection == Vector3.zero ? new Vector3(0, 0, 1) : _movementDirection; 
            _rigidbody.AddForceAtPosition(dashDirection * _dashForce, transform.position);
        }
    }

    private void ActivateCollider(bool isSphere)
    {
        if (isSphere == _isSphere)
        {
            return;
        }

        _sphereCollider.enabled = isSphere;
        _boxCollider.enabled = !isSphere;

        _isSphere = isSphere;
    }

    private void FixedUpdate()
    {
         TryActivateDash();

        if (_movementDirection == Vector3.zero && _rigidbody.velocity.magnitude > 0f)
        {
            ActivateCollider(isSphere: false);   
            return;
        }

        ActivateCollider(isSphere: true);
        _rigidbody.AddForceAtPosition(_movementDirection.normalized * _moveSpeed, transform.position);
    }
}