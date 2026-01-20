using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{

    [SerializeField]
    [Tooltip("This is the jump impulse")]
    private float _jumpImpulse = 5f;
    private Rigidbody2D _rigidbody;

    private Camera _camera;
    private Transform _transform;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            throw new NullReferenceException();
        
        _camera = Camera.main;
        _transform = transform;
    }
    void Update()

    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Jump();
            
        Vector3 position = _transform.position;

        if (Mathf.Abs(transform.position.y) > _camera.orthographicSize) 
            Debug.Log("Out of Screen");
    }

    private void Jump() { 
        _rigidbody.AddForce(Vector2.up * _jumpImpulse, ForceMode2D.Impulse);
    }

}
