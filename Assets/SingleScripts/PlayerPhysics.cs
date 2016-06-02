using UnityEngine;
using System.Collections;
using System;

public class PlayerPhysics : MonoBehaviour
{
    //references
    CharacterController cc;
    PlayerInput playerInput;
    Camera camera;


    //movement
    public float currentSpeed;
    public float walkSpeed;
    public float runSpeed;

    //gravity
    public float gravityStrength;

    //jumping
    public float jumpPower;

    //mouse Control
    private float mouseYPosition;
    public float mouseSensitivity;
    public float maxDown;
    public float maxUp;

    //Headbobbing fields
    private Vector3 movementVector;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        MovePlayer();
        AllowRunning();
        CanJump();
        Gravity();
        rotateX();
        rotateY();
    }

    void MovePlayer()
    {

        movementVector = new Vector3(playerInput.HorizontalMovement() * currentSpeed, movementVector.y, playerInput.VerticalMovement() * currentSpeed);
        cc.Move((transform.rotation * movementVector) * Time.deltaTime);
    }

    float Gravity()
    {
        if (!cc.isGrounded)
        {
            movementVector.y += Physics.gravity.y * Time.deltaTime * gravityStrength ;
        }
        return movementVector.y;
    }

    void AllowRunning()
    {
        currentSpeed = playerInput.IsRunning() ? currentSpeed = runSpeed : currentSpeed = walkSpeed;
    }

    void CanJump()
    {
        if (cc.isGrounded && playerInput.JumpHeld())
        {
            cc.height = 1;
            camera.transform.localPosition = new Vector3(0, 0.5f, 0);
        }

        if(cc.isGrounded && playerInput.JumpReleased())
        {
            //movementVector.y = Mathf.Lerp(0, jumpPower, 3f);
            movementVector.y = jumpPower;
            cc.height = 2;
            camera.transform.localPosition = new Vector3(0, 1, 0);


        }
    }

    void rotateY()
    {
        //Why does it have to be a field? needs to be initialised before it can be modified
        mouseYPosition -= playerInput.MouseY() * mouseSensitivity;
        mouseYPosition = Mathf.Clamp(mouseYPosition, maxDown, maxUp);
        camera.transform.localEulerAngles = new Vector3(mouseYPosition, 0, 0);
    }

    void rotateX()
    {
        float mouseXPosition = playerInput.MouseX() * mouseSensitivity;
        transform.Rotate(0, mouseXPosition, 0);
    }
}

