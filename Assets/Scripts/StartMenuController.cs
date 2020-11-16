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

    // Function for changing the game volume with the volume slider
    public void OnValueChanged()
    {
        // Set the master volume to the value of the slider
        AudioManager.masterVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
        AudioListener.volume = AudioManager.masterVolume;
    }

    // Function for when the options button is clicked
    public void OptionButtonClick()
    {
        // Set the volume slider value to the value of the master volume
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
