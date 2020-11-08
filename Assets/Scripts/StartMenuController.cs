using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    // Function for when the options button is clicked
    public void OptionsButtonClick()
    {
        // Set the volume slider value to the value saved in the PlayerPrefs
        GameObject.Find("VolumeSlider").GetComponent<Slider>().value = AudioManager.masterVolume;
    }

    /// <summary>
    /// Function to save the volume into PlayerPrefs
    /// </summary>
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioManager.masterVolume);
    }
}
