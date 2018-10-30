using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour {

    // Setting up variables
    private GameObject send = null;

	
	void Start () {
        // Finding gameobjects
        this.send = GameObject.Find("Rifle");

	} // Start
	
	
	void Update () {

	} // Update


    // Setting what happens on collision
    private void OnCollisionEnter(Collision collision)
    {
        // If the Player hits collectable sphere
        if (collision.gameObject.name == "Player2")
        {
            // score is updated
            this.send.GetComponent<PointsCounter>().score += 0.5f;
            // Sphere gets destroyed
            Destroy(gameObject);

        } // if

    } // OnCollisionEnter

} // Class
