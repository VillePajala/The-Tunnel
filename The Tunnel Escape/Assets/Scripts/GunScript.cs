using UnityEngine;


public class GunScript : MonoBehaviour {

    public GameObject explosion = null;
    public GameObject impactEffect;
    private AudioSource[] sounds = null;

    public float damage = 10f;
    public float range = 100f;
    public float force = 30f;

    public Camera fpsCam;

	void Start () {
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();
    } 
	
	void Update () {
        if (Input.GetButtonDown("Fire1") && PauseGame.GameIsPaused == false)
        {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            TargetScript target = hit.transform.GetComponent<TargetScript>();

            if(target != null) {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * force);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 5f);
        }
    }

} 


