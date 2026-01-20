using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the of the background")]
    private float _moveSpeed = 2f;
    
    void Update()
    {
        if (transform.position.x > -16)
            transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        else
        {
            transform.position = Vector2.zero;
        }
    }
   
}
