using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator _animator;
    int _currentState = 0;
    const string AnimatorState = "State";

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        Toggle();
    }

    void Toggle()
    {
        _currentState += 1;
        if (_currentState > 1)
        {
            _currentState = 0;
        }
        _animator.SetInteger(AnimatorState, _currentState);
    }
}
