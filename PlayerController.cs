using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _accelerationMagnitude;
    [SerializeField] private float _targetVelocityZ;
    [SerializeField] private float _screenToWorldRatio;
    [SerializeField] private float _ascendSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _strifeSpeed;
    [SerializeField] private float _dodgeSpeed;
    [SerializeField] private float _pushSpeed;

    private float _horizontalSpeed;

    private float _screenWidth;

    private Rigidbody _rigidbody;

    private Vector2 _touchStartPosition;

    public bool useGravity = true;

    void Awake ()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();

        _rigidbody.useGravity = false;
    }

    void Update()
    {
        var _horizontalAxis = Input.GetAxis("Horizontal");
        var _velocityChange = (_targetVelocityZ - _rigidbody.velocity.z) * Vector3.forward;
        _rigidbody.AddForce(_velocityChange, ForceMode.VelocityChange);

    HandleTouch();
    
    }

    public void HandleTouch ()
    {
        if(Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

           _screenWidth = Screen.width;

            Vector3 _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);

            if (useGravity)
            {
                _rigidbody.AddForce(Physics.gravity * (_rigidbody.mass * _rigidbody.mass));
            }

            if (_touch.phase == TouchPhase.Began)
            {
                _rigidbody.AddForce(0, _jumpSpeed, _pushSpeed, ForceMode.VelocityChange);

                _rigidbody.useGravity = false;

                if (_touch.position.x > _screenWidth / 2)
                {
                    _rigidbody.AddForce(_strifeSpeed, 0, _targetVelocityZ, ForceMode.VelocityChange);
                }
                else if (_touch.position.x < _screenWidth / 2)
                {
                    _rigidbody.AddForce(-_strifeSpeed, 0, _targetVelocityZ, ForceMode.VelocityChange);
                }
            }
            
            if (_touch.phase == TouchPhase.Stationary)
            {
                _rigidbody.useGravity = false;
                _rigidbody.AddForce(0, _ascendSpeed, _pushSpeed, ForceMode.Acceleration);

                if (_touch.position.x > _screenWidth / 2)
                {
                    _rigidbody.AddForce(_dodgeSpeed, 0, _targetVelocityZ, ForceMode.Acceleration);
                }
                else if (_touch.position.x < _screenWidth / 2)
                {
                    _rigidbody.AddForce(-_dodgeSpeed, 0, _targetVelocityZ, ForceMode.Acceleration);
                }
            }

            if(_touch.phase == TouchPhase.Ended)
            {
                _rigidbody.useGravity = true;
                _rigidbody.AddForce(0, 0, _pushSpeed, ForceMode.Acceleration);
                
            }
        }
    }
}
