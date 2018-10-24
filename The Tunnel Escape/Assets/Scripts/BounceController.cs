using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : MonoBehaviour {

    // Creating the soundsource
    private AudioSource[] sounds = null;

    void Start () {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    } // Start
	
	
	void Update () {
		
	} // Update

    // on collision
    private void OnCollisionEnter(Collision collision)
    {
        // if the terrain is hit by a "monster"
        if(collision.gameObject.tag == "Monster")
        {
            // Bouncing sound is played
            this.sounds[5].Play();
        } // if

    } // OnCollisionEnter

} // Class
