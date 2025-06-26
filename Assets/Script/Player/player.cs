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

    Animator animator;
    AudioSource audioSource;

    // Public audio clips for jump and land
    public AudioClip jumpSound;
    public AudioClip landSound;

    bool oneSoundjump = true;

    void Awake()
    {
        controls = new InputSystem_Actions();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
        // Play jump sound
        if (jumpSound != null )
        {
            audioSource.PlayOneShot(jumpSound);
        }
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
            audioSource.Pause();
            animator.SetBool("IsJumping", !isGrounded);
            position.y += velocity.y * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;

            if (position.y <= groundHeghit)
            {
                position.y = groundHeghit;
                isGrounded = true;
                velocity.y = 0;
                oneSoundjump = true;

                // Play land sound
                if (landSound != null)
                {
                    audioSource.PlayOneShot(landSound);
                }
            }
        }

        if (isGrounded)
        {
            if (!audioSource.isPlaying)
                {
                    audioSource.UnPause();
                }

            animator.SetBool("IsJumping", !isGrounded);
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

}
