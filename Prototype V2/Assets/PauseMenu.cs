using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public AudioSource Music;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject OptionsMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else if(GameIsPaused)
            {
                Restart();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Music.Play();
        // Sets Pause Menu to false, sets Time to 1 and continues to play the level music.

    }

    void Options()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        OptionsMenuUI.SetActive(true);
        // Sets Pause menu to false, stops time and sets Options Menu to True
    }
    

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Music.Pause();
        // Sets Pause Menu to true, stops time and pauses the level music
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        // Recalls the current scene and sets the time to 1
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu Background");
        // Calls the Menu scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
        //Ends the program
    }
    
}
