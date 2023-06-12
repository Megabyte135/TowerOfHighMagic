using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public int WalkingSpeed = 5;
    public int SprintingSpeed = 10; 
    CharacterController _characterController;
    Animator _animator;
    const float AnimationIdleSpeed = 0f;
    const float AnimationRunningSpeed = 2f;
    const float AnimationWalkForwardSpeed = 1f;
    const float AnimationWalkBackwardSpeed = -1f;
    const string AnimatorSpeed = "Speed";

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    public void Walk(Vector3 direction)
    {
        if (direction == -transform.forward)
        {
            _animator.SetFloat(AnimatorSpeed, AnimationWalkBackwardSpeed);
        }
        else if (direction == Vector3.zero)
        {
            _animator.SetFloat(AnimatorSpeed, AnimationIdleSpeed);
        }
        else
        {
            _animator.SetFloat(AnimatorSpeed, AnimationWalkForwardSpeed);
        }
        Move(direction, WalkingSpeed);
    }

    public void Sprint(Vector3 direction)
    {
        _animator.SetFloat(AnimatorSpeed, AnimationRunningSpeed);
        Move(direction, SprintingSpeed);
    }

    void Move(Vector3 direction, int speed)
    {
        Vector3 movementDistance = (direction * speed) * Time.deltaTime;
        _characterController.Move(movementDistance);
    }
}