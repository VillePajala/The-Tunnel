
using UnityEngine;

public class TargetScript : MonoBehaviour {

    // Definging variables
    public GameObject destroyedVersion;
    public GameObject priceobject;

    public float health = 50f;

    private AudioSource[] sounds = null;

    void Start()
    {

        // Finding gameobjects
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();

    } // Start

    
    public void TakeDamage(float amount)
    {
        // every shot reduces health
        health -= amount;

        // If health turns 0
        if(health <= 0f)
        {
            Die();
        } // if

    } // TakeDamage



    void Die()
    {
        // Spawn a shattered crate
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        // Spawn a price object
        Instantiate(priceobject, transform.position, transform.rotation);
        this.sounds[6].Play();
        // Remove the uncracked crate
        Destroy(gameObject);

    } // Die


} // Class
