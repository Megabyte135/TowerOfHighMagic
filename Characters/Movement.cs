using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public int WalkingSpeed = 5;
    public int SprintingSpeed = 10;
    [HideInInspector] public Vector3 Distance;
    CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Distance = Vector3.zero;
    }

    public void Walk(Vector3 direction)
    {
        Move(direction, WalkingSpeed);
    }

    public void Sprint(Vector3 direction)
    {
        Move(direction, SprintingSpeed);
    }

    void Move(Vector3 direction, int speed)
    {
        Distance = (direction * speed);
        Vector3 movementDistance = Distance * Time.deltaTime;
        _characterController.Move(movementDistance);
    }
}