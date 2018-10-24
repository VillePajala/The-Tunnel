using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour {

    // Defining gameobjects to be created
    public GameObject big_monster = null;
    private GameObject kills = null;

    // Public points variable
    public int score = 0;
	
	void Start () {

        // FInding gameobjects
        this.kills = GameObject.Find("Points");

	} // start
	
	
	void Update () {

        // if the kill score is less or equal to 9, the points variable will be printed on UI canvas
        if (score <= 9)
        {
            this.kills.GetComponent<Text>().text = "Monsters killed: " + score + "/9";

        } // if
        

        // If the kill score is equal to 9, the main enemy is instantiated and kill count set to dtatic
        if (score == 9)
        {
            Quaternion form = new Quaternion(0f, 45f, 45f, 0f);
            GameObject monster = Instantiate(this.big_monster, new Vector3(600f, 500f, 600f), form);
            score += 1;
            this.kills.GetComponent<Text>().text = "Monsters killed: 9/9";
        }

    } // Update

} // class
