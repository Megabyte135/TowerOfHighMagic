using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public AudioSettings Audio = new AudioSettings();
    public GameplaySettings Gameplay = new GameplaySettings();
    public MouseSettings Mouse = new MouseSettings();
}

[System.Serializable]
public class GameplaySettings
{
    public string AttackKey = KeyCode.Mouse0.ToString();
    public string MoveForwardKey = KeyCode.W.ToString();
    public string MoveBackwardKey = KeyCode.S.ToString();
    public string MoveLeftKey = KeyCode.A.ToString();
    public string MoveRightKey = KeyCode.D.ToString();
    public string JumpKey = KeyCode.Space.ToString();
    public string SprintKey = KeyCode.LeftShift.ToString();
    public string PauseKey = KeyCode.Escape.ToString();
    public string InventoryKey = KeyCode.I.ToString();
    public string InteractKey = KeyCode.E.ToString();
    public string CharacterSheetKey = KeyCode.C.ToString();
}

[System.Serializable]
public class MouseSettings
{
    public float MouseSensitivity = 1f;
}

[System.Serializable]
public class AudioSettings
{
    public float GeneralVolume = 0.5f;
    public float MusicVolume = 0.5f;
    public float EffectVolume = 0.5f;
}