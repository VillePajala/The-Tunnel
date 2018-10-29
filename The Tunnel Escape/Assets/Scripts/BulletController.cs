using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // Defining public gameobjects to drag from editor
    // public GameObject bullet = null;
    public ParticleSystem explosion = null;

    // Variable for adding force on impact
    public float force = 100f;

    // Soundsource
    private AudioSource[] sounds = null;



    void Start () {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    } // Start
	
	
	void Update () {
		
        // If left mouse button is pressed
        if (Input.GetButtonUp("Fire1") && PauseGame.GameIsPaused == false)
        {
            // sound of gunshot is played
            this.sounds[2].Play();
            // calling a method for another sound after delay
            Invoke("PlayShellSound", 1f);
            // Creating a new explosion from prefab
            explosion.Play();
            // Explosion destroyed after delay
            // Destroy(exp, 5f);
            // Creating a new bullet from prefab
            // GameObject ammo = Instantiate(this.bullet, this.GetComponent<Transform>().position, Quaternion.identity);
            // Bullet is given a name
            // ammo.name = "killer";
            // Bullet is given a "shoting" force
            // ammo.GetComponent<Rigidbody>().AddForce(this.GetComponent<Transform>().forward * this.force);
            // Bullet destroyed after delay
            // Destroy(ammo, 20f);
        } // if


    } // Update


    // After delay, the sound of bullet shelll dropping to the ground is played
    void PlayShellSound()
    {
        this.sounds[3].Play();
    }

} // Class
