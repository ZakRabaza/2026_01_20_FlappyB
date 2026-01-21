using UnityEngine;

public class PipeController : MonoBehaviour
{
    [Header("Pipe Settings")]

    [Range(1f, 10f)]
    [SerializeField]
    [Tooltip("This is the move speed of the pipes")]
    private float _moveSpeed = 2f;

    [Tooltip("This is the gap between the pipe")]
    [SerializeField] 
    private float _gap = 4f;

    [Tooltip("This is the minimum height of center between the pipe , space included")]
    [SerializeField] 
    private float _minCenterY = -6f;

    [Tooltip("This is the maximum height of center between the pipe , space included")]
    [SerializeField] 
    private float _maxCenterY = 6f;

    private Transform _pipeUp;
    private Transform _pipeDown;

  
    void Update()
    {
        MovePipe();
    }

    public void Init()
    {
        _pipeUp = transform.Find("PipeUp");
        _pipeDown = transform.Find("PipeDown");
    }

    void MovePipe()
    {
        Vector2 translation = _moveSpeed * Time.deltaTime * Vector2.left;
        transform.Translate(translation);

        if (transform.position.x < -16f) 
            gameObject.SetActive(false);
    }
    public void EditPipeAttributes()
    {
        float centerY = Random.Range(_minCenterY, _maxCenterY);
    
        _pipeUp.localPosition = new Vector2(0, centerY - _gap / 2f);
        _pipeDown.localPosition = new Vector2(0, centerY + _gap / 2f);

    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Bird Dead RIP");
    //}
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Bird Dead RIP");
    //}
}
