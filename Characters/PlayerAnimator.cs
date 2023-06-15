using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    Movement _movement;
    Jumping _jumping;
    Attacking _attacking;
    Animator _animator;
    bool _isJumpingTriggerSet = false;
    const float AnimationIdleSpeed = 0f;
    const float AnimationWalkForwardSpeed = 0.5f;
    const float AnimationWalkBackwardSpeed = -0.5f;
    const float AnimationRunningSpeed = 1f;
    const string AnimatorSpeed = "Speed";
    const string IsJumping = "IsJumping";

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _jumping = GetComponent<Jumping>();
        _attacking = GetComponent<Attacking>();
    }

    void Update()
    {
        if (!_jumping.IsGrounded && !_isJumpingTriggerSet)
        {
            _animator.SetTrigger(IsJumping);
            _isJumpingTriggerSet = true;
        }
        else if (_jumping.IsGrounded)
        {
            _isJumpingTriggerSet = false;
        }
        _animator.SetFloat(AnimatorSpeed, DetermineSpeed());
    }

    float DetermineSpeed()
    {
        Vector3 localMovementDirection = transform.InverseTransformDirection(_movement.Distance);
        float movementDirectionByZ = localMovementDirection.z;
        if (movementDirectionByZ < 0f)
        {
            return -0.5f;
        }
        else if (movementDirectionByZ >= _movement.SprintingSpeed)
        {
            return 1f;
        }
        else if (movementDirectionByZ > 0)
        {
            return 0.5f;
        }
        else
        {
            return 0f;
        }
    }
}
