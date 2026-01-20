using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the of the background")]
    private float _moveSpeed = 2f;

    void Update()
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
