using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

	public float HorizontalMovement()
    {
        float horizontalMove = Input.GetAxis("Horizontal") ;

        return horizontalMove;
    }

    public float VerticalMovement()
    {
        float verticalMove = Input.GetAxis("Vertical") ;

        return verticalMove;
    }

    public bool IsRunning()
    {
        bool running = Input.GetKey(KeyCode.LeftShift);

        return running;
    }

    public float MouseX()
    {
        float mouseXPosition = Input.GetAxis("Mouse X");
        return mouseXPosition;
    }

    public float MouseY()
    {
        float mouseYPosition = Input.GetAxis("Mouse Y");

        return mouseYPosition;
    }

    public bool JumpHeld()
    {
        bool jumpHeld = Input.GetButton("Jump");

        return jumpHeld;
    }


    public bool JumpReleased()
    {
        bool jumpReleased = Input.GetButtonUp("Jump");
        return jumpReleased;
    }
}
