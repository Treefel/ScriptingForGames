using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private SimpleCharacterController controller;
    private Vector3 velocity;
    private Vector3 movementVector = Vector3.zero;
    private CharacterController mover;

    private Animator animator;
    private enum MovementState {  idle, running, jumping, falling, hit  };
    private SpriteRenderer sprite;
    

    private void Start()
    {
        controller = GetComponentInParent<SimpleCharacterController>();
        mover = GetComponentInParent<CharacterController>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    private void Update()
    {
        velocity = controller.velocity;
        movementVector = controller.movementVector;
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        MovementState state;

        if ((movementVector.x > 0) && mover.isGrounded)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if ((movementVector.x < 0) && mover.isGrounded)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if ((velocity.y > 0) && !mover.isGrounded)
        {
            state = MovementState.jumping;
        }
        else if ((velocity.y < 0) && !mover.isGrounded)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }
}
