using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsCounter : MonoBehaviour {

    public float score = 0;
    public GameObject collected = null;
    public GameObject endscreen;

	
	void Start () {
        this.collected = GameObject.Find("Points");
	} 
	
	
	void Update () {
        this.collected.GetComponent<TMP_Text>().text = "Spheres collected " + score + "/20";

        if(score == 20)
        {
            endscreen.gameObject.SetActive(true);
            Invoke("EndMenu", 2.5f);
        } 
	}

    void EndMenu() {
        SceneManager.LoadScene(2);
    }

} 
