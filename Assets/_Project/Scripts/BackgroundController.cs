using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Background Settings")]

    [SerializeField]
    [Range(1f, 10f)]
    [Tooltip("This is the move speed of the background")]
    private float _moveSpeed = 2f;

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        Vector2 translation = _moveSpeed * Time.deltaTime * Vector2.left;
        if (transform.position.x > -16)
            transform.Translate(translation);
        else
        {
            transform.position = Vector2.zero;
        }
    }
   
}
