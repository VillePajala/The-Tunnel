using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsCounter : MonoBehaviour {

    public float score = 0;
    public GameObject collected = null;

	// Use this for initialization
	void Start () {
        this.collected = GameObject.Find("Points");
	}
	
	// Update is called once per frame
	void Update () {

        this.collected.GetComponent<TMP_Text>().text = "Spheres collected " + score + "/30";
		
	}
}
