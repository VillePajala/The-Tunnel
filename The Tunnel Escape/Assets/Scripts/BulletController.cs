using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public ParticleSystem muzzlefire = null;
    public GameObject explosion = null;
    public GameObject impactEffect;

    private AudioSource[] sounds = null;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float force = 30f;

    private float nextTimeToFire = 0f;
    public Camera fpsCam;


    void Start () {
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();
    } 
	
	
	void Update () {
        if (Input.GetButton("Fire1") && PauseGame.GameIsPaused == false && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            this.sounds[2].Play();
            Invoke("PlayShellSound", 1f);
            muzzlefire.Play();
            Shoot();
        } 
    } 

    void PlayShellSound() {
        this.sounds[3].Play();
    } 


    void Shoot() {
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
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 5f);
        }
    }


}
