using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float gravity;
    public float distance;
    public float maxXVelocity = 100;
    public Vector2 velocity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float jumpVelocity = 20;
    public float groundHeghit = 10;
    public bool isGrounded = false;

    public float minJumpHeight = 1.0f; // Minimum height to reach before fall
    private float jumpStartY;

    private InputSystem_Actions controls;
    private bool jumpPressed = false;
    private bool jumpHeld = false;

    void Awake()
    {
        controls = new InputSystem_Actions();

        // When jump starts
        controls.Player.Jump.started += ctx =>
        {
            jumpPressed = true;
            jumpHeld = true;
        };

        // When jump is released
        controls.Player.Jump.canceled += ctx =>
        {
            jumpHeld = false;
        };
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        if (isGrounded && jumpPressed)
        {
            isGrounded = false;
            velocity.y = jumpVelocity;
            jumpPressed = false;
            jumpStartY = transform.position.y; // Store jump start height
        }

        // Only reduce velocity if minimum height is reached
        if (!jumpHeld && velocity.y > 0)
        {
            float heightSoFar = transform.position.y - jumpStartY;

            if (heightSoFar >= minJumpHeight)
            {
                velocity.y *= 0.5f; // Cut upward velocity for short jump
            }
        }
        Vector2 position = transform.position;

        if (!isGrounded)
        {
            position.y += velocity.y * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime;

            if (position.y <= groundHeghit)
            {
                position.y = groundHeghit;
                isGrounded = true;
                velocity.y = 0;
            }
        }
        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            velocity.x += acceleration * Time.deltaTime;
            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }
        distance += velocity.x * Time.deltaTime;

        transform.position = position;

    }

    private void FixedUpdate()
    {

    }
}
