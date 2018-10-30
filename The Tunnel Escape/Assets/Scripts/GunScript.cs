
using UnityEngine;


// CODE NOT IN USE BUT SAVED FOR NOTES!

public class GunScript : MonoBehaviour {

    // Defining variables
    
    public GameObject explosion = null;

    public GameObject impactEffect;

    // Soundsource
    private AudioSource[] sounds = null;

    public float damage = 10f;
    public float range = 100f;
    public float force = 30f;

    public Camera fpsCam;


	
	void Start () {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    } // start
	
	
	void Update () {

        // If left mouse button is pressed 
        if (Input.GetButtonDown("Fire1") && PauseGame.GameIsPaused == false)
        {

            Shoot();

        } // if


    } // Update

    void Shoot()
    {
       
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            

            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
                // this.sounds[4].Play();
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 5f);
        }
    }

    


} // Class
