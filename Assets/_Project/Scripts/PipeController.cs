using UnityEngine;

public class PipeController : MonoBehaviour
{
    [Header("Pipe Settings")]

    [SerializeField]
    [Range(1f, 10f)]
    [Tooltip("This is the move speed of the pipes")]
    private float _moveSpeed = 2f;

    [SerializeField] 
    [Tooltip("This is the gap between the pipe")]
    private float _gap = 4f;

    [SerializeField] 
    [Tooltip("This is the minimum height of center between the pipe , space included")]
    private float _minCenterY = -6f;

    [SerializeField] 
    [Tooltip("This is the maximum height of center between the pipe , space included")]
    private float _maxCenterY = 6f;


    private Transform _pipeUp;
    private Transform _pipeDown;

    private Transform _scoreZone; 
    private BoxCollider2D _scoreCollider;


    void Update()
    {
        MovePipe();
    }

    public void Init()
    {
        _pipeUp = transform.Find("PipeUp");
        _pipeDown = transform.Find("PipeDown");

        _scoreZone = transform.Find("ScoreZone"); 
        _scoreCollider = _scoreZone.GetComponent<BoxCollider2D>();
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

        _scoreZone.localPosition = new Vector2(2.5f, centerY);
        _scoreCollider.size = new Vector2(1f, _gap);
    }
}
