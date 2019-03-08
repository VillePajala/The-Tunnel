using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour {

    private GameObject send = null;

	void Start () {
        this.send = GameObject.Find("Rifle");
	} 
	
	void Update () {

	}

    private void OnCollisionEnter(Collision collision) {  
        if (collision.gameObject.name == "Player2") {
            this.send.GetComponent<PointsCounter>().score += 0.5f;
            Destroy(gameObject);
        } 
    } 

} 
