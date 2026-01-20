using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [Header("Bird Settings")]

    [Range(1f, 10f)]
    [SerializeField]
    [Tooltip("This is the jump impulse")]
    private float _jumpImpulse = 5f;

    [Range(-10f, 0f)]
    [SerializeField]
    [Tooltip("This is the negative velocity")]
    private float _negativeVelocity = -10f;

    [Range(0f, 10f)]
    [SerializeField]
    [Tooltip("This is the positive velocity")]
    private float _positiveVelocity = 10f;
    
    private Rigidbody2D _rigidbody;
    private Camera _camera;
    private Transform _transform;
    private Animator _animator;

    void Start()
    {
        InitValues();
    }
  
    void Update()
    {
        HandleInput();
        HandleOutOfCamera();
        LimitVelocity();
    }

    void InitValues()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            throw new NullReferenceException();

        _camera = Camera.main;
        _transform = transform;
        _animator = GetComponent<Animator>();
    }

    void Jump() { 
        _rigidbody.AddForce(Vector2.up * _jumpImpulse, ForceMode2D.Impulse);
        _animator.SetTrigger("Flap");
    }

    void HandleInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Jump();
    }

    void HandleOutOfCamera()
    {
        Vector3 position = _transform.position;

        if (Mathf.Abs(position.y) > _camera.orthographicSize)
            Debug.Log("Out of Screen");
    }

    void LimitVelocity() {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, Mathf.Clamp(_rigidbody.linearVelocity.y, _negativeVelocity, _positiveVelocity));
    }
}
