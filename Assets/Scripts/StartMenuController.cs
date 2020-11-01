using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    // Function for the PlayButton to load the PlayScene
    public void PlayButtonClick()
    {
        SceneManager.LoadSceneAsync("PlayScene");
    }

    // Function for the QuitButton to close the game
    public void QuitButtonClick()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }

}
