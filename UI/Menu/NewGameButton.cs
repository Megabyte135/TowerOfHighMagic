using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public string StartingScene = "Starting Scene";
    public void NewGame()
    {
        SceneManager.LoadScene(StartingScene);
    }
}
