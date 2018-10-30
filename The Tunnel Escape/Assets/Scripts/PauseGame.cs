using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    // Defining gameobjects

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private GameObject score = null;

    private GameObject character = null;

    void Start()
    {
        // Finding gameobjects
        this.score = GameObject.Find("Points");
        this.character = GameObject.Find("Player2");
        Resume();

    }


    
    void Update () {

        // If the esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

            } else
            {
                Pause();
               

            } // else

        } // if

	} // Update



    public void Resume()
    {
        // Pausemenu gets de-activated
        pauseMenuUI.SetActive(false);
        // Game time is re-enabled
        Time.timeScale = 1f;
        // variable changed
        GameIsPaused = false;
        // fpc controller enabled
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        // Mouse cursor hidden
        Cursor.visible = false;
        Screen.lockCursor = true;
        this.score.gameObject.SetActive(true);

    }

    void Pause()
    {
        // Pausemenu gets activated
        pauseMenuUI.SetActive(true);
        // Game time is stopped
        Time.timeScale = 0f;
        // variable changed
        GameIsPaused = true;
        // fpc controller disabled
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        // Mouse cursor unhidden
        Cursor.visible = true;
        Screen.lockCursor = false;
        this.score.gameObject.SetActive(false);
        
    }

    public void LoadScene()
    {
        // Everything is truned back to normal on level reload
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        Cursor.visible = false;
        Screen.lockCursor = true;

    }

    // Game is stopped
    public void QuitGame()
    {
        
        Application.Quit();
    }

} // Class
