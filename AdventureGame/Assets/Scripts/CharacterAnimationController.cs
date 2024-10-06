using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{

    private Animator animator;
    private enum MovementState {  idle, running, jumping, falling  };
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        MovementState state;

        if (Input.GetAxis("Horizontal") != 0)
        {
            print("running");
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Input.GetButtonDown("Jump"))
        {
            print("jumping");
            state = MovementState.jumping;
        }

        animator.SetInteger("state", (int)state);
    }
}
