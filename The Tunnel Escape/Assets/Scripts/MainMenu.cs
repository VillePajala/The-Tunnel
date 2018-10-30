using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // If the play button is pressed, PlayGame -function is called

	public void PlayGame()
    {
        // If current scene is the intro scene, the next scene is loaded
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // If the current scene is not intro scene, the previous scene is loaded
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            
        }
        
    }

    // If the quot game button si pressed, game stops
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
