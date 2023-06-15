using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    public GameObject PauseUI;
    PlayerInput _playerInput;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void Pause()
    {
       if (Time.timeScale > 0)
        {
            _playerInput.enabled = false;
            Time.timeScale = 0;
            PauseUI.SetActive(true);
        }
        else
        {
            _playerInput.enabled = true;
            Time.timeScale = 1;
            PauseUI.SetActive(false);
        }
    }
}
