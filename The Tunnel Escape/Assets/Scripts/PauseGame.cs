using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject score = null;
    private GameObject character = null;

    void Start() {
        this.score = GameObject.Find("Points");
        this.character = GameObject.Find("Player2");
        Resume();
    }


    
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            } 
        } 
	} 



    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        Cursor.visible = false;
        Screen.lockCursor = true;
        this.score.gameObject.SetActive(true);
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        Cursor.visible = true;
        Screen.lockCursor = false;
        this.score.gameObject.SetActive(false);
    }

    public void LoadScene() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.character.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        Cursor.visible = false;
        Screen.lockCursor = true;
    }

    public void QuitGame() {
        Application.Quit();
    }

} 
