using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GravityEmulation : MonoBehaviour
{
    const float _gravity = 1f;
    CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        Vector3 velocity = Vector3.down * _gravity*Time.deltaTime;
        _characterController.Move(velocity);
    }
}
