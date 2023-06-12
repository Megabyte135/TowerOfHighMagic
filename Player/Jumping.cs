using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jumping : MonoBehaviour
{
    //TO DO:
    public float JumpHeight = 0.5f;
    [SerializeField] float _characterHeight = 1.0f;
    CharacterController _characterController;
    Animator _animator;
    const string IsJumping = "IsJumping";
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _animator.SetTrigger(IsJumping);
            _characterController.Move(Vector3.up * JumpHeight);
        }
    }

    bool IsGrounded()
    {
        float raycastDistance = 1.5f;
        Vector3 origin = transform.position;
        origin.y += _characterHeight;

        Ray ray = new Ray(origin, Vector3.down);

        if (Physics.Raycast(ray, raycastDistance))
        {
            return true;
        }
        return false;
    }
}
