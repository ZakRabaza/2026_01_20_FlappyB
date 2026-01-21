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
    private float minCenterY = -6f;

    [Tooltip("This is the maximum height of center between the pipe , space included")]
    [SerializeField] 
    private float maxCenterY = 6f;

    private Transform _pipeUp;
    private Transform _pipeDown;

    void Start()
    {
        SetInitPositions();
    }

    void Update()
    {
        MovePipe();
    }

    void SetInitPositions()
    {
        _pipeUp = transform.Find("PipeUp");
        _pipeDown = transform.Find("PipeDown");

        _pipeUp.localPosition = new Vector2(0, -2f);
        _pipeDown.localPosition = new Vector2(0, 2f);    
    }

    void MovePipe()
{
        Vector2 translation = _moveSpeed * Time.deltaTime * Vector2.left;
        if (transform.position.x > -16)
            transform.Translate(translation);
        else
        {
            transform.position = Vector2.zero;
            EditPipeAttributes();
        }
    }
    void EditPipeAttributes()
    {
        float centerY = Random.Range(minCenterY, maxCenterY);
    
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
