using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    // Keep track if the game is paused or not
    public static bool gameIsPaused = false;

    // Reference the UI to control it
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Debug.Log("Resume Clicked");
        pauseMenuUI.SetActive(false);
        // Freeze time (timeScale = speed at which speed is passing)
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ResetButtonClicked()
    {
        Debug.Log("Reset Clicked");
        BallController bc = GameObject.Find("Ball").GetComponent<BallController>();
        bc.ResetGame();
    }


    // Function to pause the game
    private void PauseGame()
    {
        Debug.Log("Pause Clicked");
        pauseMenuUI.SetActive(true);
        // Freeze time (timeScale = speed at which speed is passing)
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Function for ExitButton functionality
    public void ExitButtonClick()
    {
        Debug.Log("Exit Clicked");
    }
}
