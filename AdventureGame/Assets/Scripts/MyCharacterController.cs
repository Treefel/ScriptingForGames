using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{

    private Animator animator;
    private enum MovementState {  idle, running, jumping, falling, hit  };
    private SpriteRenderer sprite;
    

    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 velocity;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
        JumpCharacter();
        HandleAnimations();
        if (controller.isGrounded) 
        {
            print("isGrounded");
        }
    }

    private void MoveCharacter() 
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector *= (moveSpeed * Time.deltaTime);
        controller.Move(movementVector);

    }

    private void JumpCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }

    private void HandleAnimations()
    {

        MovementState state;

         if (movementVector.x > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            //print("isRRunning");
        }
        else if (movementVector.x < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            //print("isLRunning");
        }
        else
        {
            state = MovementState.idle;
            //print("isIdling");
        }

        if (velocity.y > .1f)
        {
            state = MovementState.jumping;
            //print("isJumping");
        }
        else if (!controller.isGrounded)
        {
            state = MovementState.falling;
            //print("isFalling");
        }

        animator.SetInteger("state", (int)state);
        print(state);
    }
}
