using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{

    public float jumpForce = 5f;

    void Start()
    {
        Debug.Log("Bird ready");
    }

    void Update()
    {
      if(Keyboard.current.spaceKey.wasPressedThisFrame)
        Debug.Log("Space Pressed");

      //if (Mouse.current.leftButton.isPressed)
      //  Debug.Log("Left Button Pressed");

    }
}
