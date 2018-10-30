using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsCounter : MonoBehaviour {

    // Defining variables
    public float score = 0;
    public GameObject collected = null;
    public GameObject endscreen;

	
	void Start () {

        // Finding gameobjects
        this.collected = GameObject.Find("Points");
  
	} // start
	
	
	void Update () {

        // Current score is printed to UI
        this.collected.GetComponent<TMP_Text>().text = "Spheres collected " + score + "/20";


        // If player gets enopugh points
        if(score == 20)
        {
            // animated UI image is enabled
            endscreen.gameObject.SetActive(true);
            // after delay, load scene
            Invoke("EndMenu", 2.5f);
            
        } // if
		
	} // Update

    // end Screen is loaded
    void EndMenu()
    {
        SceneManager.LoadScene(2);
       
    } // EndMenu

} // Class
