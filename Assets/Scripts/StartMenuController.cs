using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    // Function for the PlayButton to load the PlayScene
    public void PlayButtonClick()
    {
        // Stop the start menu audio
        FindObjectOfType<AudioManager>().Stop("StartMenuTheme");

        // Play the game start sound
        FindObjectOfType<AudioManager>().Play("GameStart");

        SceneManager.LoadSceneAsync("PlayScene");

        // Start the play audio
        FindObjectOfType<AudioManager>().Play("PlayTheme");
    }

    // Function for the QuitButton to close the game
    public void QuitButtonClick()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }

}
