using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerScreenController : MonoBehaviour
{
    public static bool gameHasEnded = false;

    // Reference the end screen UI to control it
    public GameObject endScreenUI;

    public TextMeshProUGUI winnerText;

    /// <summary>
    /// Function to show the winner screen ui with the winner text
    /// </summary>
    /// <param name="winner">the name of the winner</param>
    public void EndGame(string winner)
    {
        // Show the end screen ui
        endScreenUI.SetActive(true);
        // Freeze time
        Time.timeScale = 0f;
        gameHasEnded = true;

        winnerText = GameObject.Find("WinnerText").GetComponent<TextMeshProUGUI>();
        winnerText.text = winner + " wins!!!";
    }

    // Function to reset the game
    public void ResetButtonClicked()
    {
        Time.timeScale = 1f;
        gameHasEnded = false;

        // Reset game volume
        FindObjectOfType<AudioManager>().ResetVolume();

        // Reset play theme when resetting
        FindObjectOfType<AudioManager>().Stop("PlayTheme");
        FindObjectOfType<AudioManager>().Play("PlayTheme");

        // Reload current scene to reset everything
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    // Function to exit back to the start menu
    public void ExitButtonClick()
    {
        Time.timeScale = 1f;
        gameHasEnded = false;

        // Reset game volume
        FindObjectOfType<AudioManager>().ResetVolume();
        // Stop the play audio
        FindObjectOfType<AudioManager>().Stop("PlayTheme");

        SceneManager.LoadSceneAsync("StartMenuScene");
        // Start the start menu audio
        FindObjectOfType<AudioManager>().Play("StartMenuTheme");
    }
}
