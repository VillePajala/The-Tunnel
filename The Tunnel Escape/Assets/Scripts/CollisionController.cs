using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    // Defining gameobjects
    public GameObject exp2 = null;
    // Soundsource
    private AudioSource[] sounds = null;

    void Start () {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    } // Start
	
	
	void Update () {
		
	} // Update


    // When this gameobject hits something (the bullet in this case)
    private void OnCollisionEnter(Collision collision)
    {
        // sound of explosion is palyed
        this.sounds[4].Play();
        // Explosion effect is created
        GameObject explosion2 = Instantiate(this.exp2, this.GetComponent<Transform>().position, Quaternion.identity);
        // Explosion effect is destroyed after delay
        Destroy(explosion2, 8f);
        // The bullet is destroyed on impact
        Destroy(gameObject);

    } // OnCollisionEnter

} // Class
