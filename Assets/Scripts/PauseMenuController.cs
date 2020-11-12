using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    // Keep track if the game is paused or not
    public static bool gameIsPaused = false;

    // Reference the pause menu UI to control it
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !WinnerScreenController.gameHasEnded)
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Function to resume the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        // Freeze time (timeScale = speed at which speed is passing)
        Time.timeScale = 1f;
        gameIsPaused = false;
        // Reset game volume
        FindObjectOfType<AudioManager>().ResetVolume();
    }

    // Function to pause the game
    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        // Freeze time (timeScale = speed at which speed is passing)
        Time.timeScale = 0f;
        gameIsPaused = true;
        // Lower volume to 25% while in pause menu
        AudioListener.volume *= 0.25f;
    }

    // Function to reset the game
    public void ResetButtonClicked()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
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
        // Reset everything so it starts a new game with normal timeScale
        gameIsPaused = false;
        Time.timeScale = 1f;

        // Reset game volume
        FindObjectOfType<AudioManager>().ResetVolume();
        // Stop the play audio
        FindObjectOfType<AudioManager>().Stop("PlayTheme");

        SceneManager.LoadSceneAsync("StartMenuScene");
        // Start the start menu audio
        FindObjectOfType<AudioManager>().Play("StartMenuTheme");
    }
}
