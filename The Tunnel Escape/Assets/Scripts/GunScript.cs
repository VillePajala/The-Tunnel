
using UnityEngine;

public class GunScript : MonoBehaviour {

    // Defining public gameobjects to drag from editor
    
    public GameObject explosion = null;

    public GameObject impactEffect;

    // Variable for adding force on impact
    // public float force = 100f;

    // Soundsource
    private AudioSource[] sounds = null;

    public float damage = 10f;
    public float range = 100f;
    public float force = 30f;

    public Camera fpsCam;


	// Use this for initialization
	void Start () {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1") && PauseGame.GameIsPaused == false)
        {
            Shoot();
        }


    } // Update

    void Shoot()
    {
       
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

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
