using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rotation))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Jumping))]
[RequireComponent(typeof(Interaction))]
public class PlayerInput : Creature
{
    public Camera Camera;
    SettingsManager _settingsManager;
    Movement _movement;
    Rotation _characterRotation;
    Rotation _cameraRotation;
    Attacking _attacking;
    Interaction _interaction;
    Jumping _jumping;
    GameplaySettings _gameplaySettings;
    MouseSettings _mouseSettings;
    Pausing _pause;
    const string MouseAxisX = "Mouse X";
    const string MouseAxisY = "Mouse Y";
    void Start()
    {
        _settingsManager = SettingsManager.instance;
        _gameplaySettings = _settingsManager.Settings.Gameplay;
        _mouseSettings = _settingsManager.Settings.Mouse;
        _movement = GetComponent<Movement>();
        _jumping = GetComponent<Jumping>();
        _characterRotation = GetComponent<Rotation>();
        _interaction = GetComponent<Interaction>();
        _attacking = GetComponent<Attacking>();
        _cameraRotation = Camera.GetComponent<Rotation>();
        _pause = GetComponent<Pausing>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
        Attack();
        Interact();
        Pause();
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

    void Pause()
    {
        if (GetKeyDown(_gameplaySettings.PauseKey))
        {
            _pause.Pause();
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

    public override void Disable()
    {
        this.enabled = false;
    }
}
