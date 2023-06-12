using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rotation))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Jumping))]
[RequireComponent(typeof(Interaction))]
public class PlayerInput : MonoBehaviour
{
    public SettingsManager SettingsManager;
    public Camera Camera;
    Movement _movement;
    Rotation _characterRotation;
    Rotation _cameraRotation;
    Attacking _attacking;
    Interaction _interaction;
    Jumping _jumping;
    GameplaySettings _gameplaySettings;
    MouseSettings _mouseSettings;
    const string MouseAxisX = "Mouse X";
    const string MouseAxisY = "Mouse Y";
    void Start()
    {
        _gameplaySettings = SettingsManager.Settings.Gameplay;
        _mouseSettings = SettingsManager.Settings.Mouse;
        _movement = GetComponent<Movement>();
        _jumping = GetComponent<Jumping>();
        _characterRotation = GetComponent<Rotation>();
        _interaction = GetComponent<Interaction>();
        _cameraRotation = Camera.GetComponent<Rotation>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
        //Attack();
        Interact();
    }

    void Move()
    {
        Vector3 movementByAxisX = GetHorizontal();
        Vector3 movementByAxisZ = GetVertical();
        Vector3 direction = movementByAxisZ + movementByAxisX;
        if (GetKey(_gameplaySettings.SprintKey) && GetKey(_gameplaySettings.MoveForwardKey))
        {
            _movement.Sprint(direction);
        }
        else
        {
            _movement.Walk(direction);
        }
    }
    void Rotate()
    {
        float sensitivity = _mouseSettings.MouseSensitivity;
        float rotationAxisX = Input.GetAxis(MouseAxisX);
        float rotationAxisY = Input.GetAxis(MouseAxisY);
        _cameraRotation.RotateByAxisY(rotationAxisY, sensitivity);
        _characterRotation.RotateByAxisX(rotationAxisX, sensitivity);
    }

    void Jump()
    {
        if (GetKeyDown(_gameplaySettings.JumpKey))
        {
            _jumping.Jump();
        }
    }

    void Attack()
    {
        if (GetKeyDown(_gameplaySettings.AttackKey))
        {
            _attacking.Attack();
        }
    }

    void Interact()
    {
        if (GetKeyDown(_gameplaySettings.InteractKey))
        {
            _interaction.Interact();
        }
    }

    Vector3 GetVertical()
    {
        if (GetKey(_gameplaySettings.MoveForwardKey))
        {
            return transform.forward;
        }
        if (GetKey(_gameplaySettings.MoveBackwardKey))
        {
            return -transform.forward;
        }
        return Vector3.zero;
    }

    Vector3 GetHorizontal()
    {
        if (GetKey(_gameplaySettings.MoveRightKey))
        {
            return transform.right;
        }
        if (GetKey(_gameplaySettings.MoveLeftKey))
        {
            return -transform.right;
        }
        return Vector3.zero;
    }

    bool GetKeyDown(string key)
    {
        KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), key);
        if (Input.GetKeyDown(keyCode))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool GetKey(string key)
    {
        KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), key);
        if (Input.GetKey(keyCode))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
