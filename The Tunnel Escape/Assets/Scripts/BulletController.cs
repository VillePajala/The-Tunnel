using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // Setting up variables

   
    public ParticleSystem muzzlefire = null;

    public GameObject explosion = null;

    public GameObject impactEffect;

    // Soundsource
    private AudioSource[] sounds = null;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float force = 30f;

    private float nextTimeToFire = 0f;

    public Camera fpsCam;


    void Start () {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    } // Start
	
	
	void Update () {
		
        // If left mouse button is pressed AND game is not paused
        if (Input.GetButton("Fire1") && PauseGame.GameIsPaused == false && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            // sound of gunshot is played
            this.sounds[2].Play();
            // calling a method for another sound after delay
            Invoke("PlayShellSound", 1f);
            // Playing the explosion particle effect
            muzzlefire.Play();
            // Calling the Shoot -function
            Shoot();

        } // if

    } // Update


    // After delay, the sound of bullet shelll dropping to the ground is played
    void PlayShellSound()
    {
        this.sounds[3].Play();

    } // PlayShellSound


    // Shooting function
    void Shoot()
    {
        // Creating raycast
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {


            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
                // this.sounds[4].Play();
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 5f);
        }
    }




} // Class
