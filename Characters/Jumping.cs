using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jumping : MonoBehaviour
{
    public bool IsGrounded;
    public float JumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    [SerializeField] float _characterHeight = 1.0f;
    CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        IsGrounded = CheckIfGrounded();
        if (IsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * gravityValue);
        }
    }

    bool CheckIfGrounded()
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