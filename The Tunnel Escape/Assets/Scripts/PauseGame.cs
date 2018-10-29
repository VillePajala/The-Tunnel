using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private GameObject character = null;

    void Start()
    {
        this.character = GameObject.Find("Player2");
    }


    // Update is called once per frame
    void Update () {

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        Cursor.visible = false;
        
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        Cursor.visible = true;
        
    }

    public void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        Application.Quit();
    }

} // Class
