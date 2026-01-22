using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [Header("Bird Settings")]

    [SerializeField]
    [Range(1f, 10f)]
    [Tooltip("This is the jump impulse")]
    private float _jumpImpulse = 5f;

    [SerializeField]
    [Range(-10f, 0f)]
    [Tooltip("This is the negative velocity")]
    private float _negativeVelocity = -10f;

    [SerializeField]
    [Range(0f, 10f)]
    [Tooltip("This is the positive velocity")]
    private float _positiveVelocity = 10f;
    
    private Rigidbody2D _rigidbody;
    private Camera _camera;
    private Transform _transform;
    private Animator _animator;

    private bool _isDead = false;

    public event Action OnDeath;
    public event Action Score;

    void Start()
    {
        InitValues();
    }
  
    void Update()
    {
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

    void HandleOutOfCamera()
    {
        Vector3 position = _transform.position;

        if (Mathf.Abs(position.y) > _camera.orthographicSize) 
        { 
            OnDeath?.Invoke();
            Debug.Log("Out of Screen");
        }
    }

    void LimitVelocity() {
        _rigidbody.linearVelocity = new Vector2(
            _rigidbody.linearVelocity.x, 
            Mathf.Clamp(_rigidbody.linearVelocity.y, 
            _negativeVelocity, 
            _positiveVelocity
            )
        );
    }


    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (_isDead) return; 
        if (collision.collider.CompareTag("Pipe")) 
        { 
            _isDead = true;
            OnDeath?.Invoke();
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) return;
        if (collision.CompareTag("Score"))
        {
            Score?.Invoke();
        }
    }

    public void OnJumpInput(InputAction.CallbackContext _context) 
    { 
        if (!_context.started) 
            return; 
        Jump(); 
    }
    //To Do escape to pause
}
