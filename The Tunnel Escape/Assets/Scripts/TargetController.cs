using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    // Defining gameobjects
    public GameObject exp3 = null;
    private GameObject score = null;

    private int hits = 0;


    void Start () {

        // Finding gameobjects
        this.score = GameObject.Find("Player");
		
	} // Start
	
	
	void Update () {

        // if the enemy is hit three times
        if(hits >= 3)
        {
            // the Explosion effects is created
            GameObject explosion = Instantiate(this.exp3, this.GetComponent<Transform>().position, Quaternion.identity);
            // the Explosion effects is destroyed
            Destroy(explosion, 8f);
            // the enemy is destroyed
            Destroy(this.gameObject);
            // the score count increased by 1 in other script
            this.score.GetComponent<PointsCounter>().score += 1;

        } // if
		
	} // Update

    // on collision
    private void OnCollisionEnter(Collision collision)
    {
        // if the gameobject is hit by another object named "killer"
        if (collision.gameObject.name == "killer")
        {
            // The gameobjects gravity is turned on so it drops
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            // hits counter increased by 1
            hits += 1;

        } // if
            
    } // OnCollisionEnter

} // Class
