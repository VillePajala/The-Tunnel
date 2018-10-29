
using UnityEngine;

public class TargetScript : MonoBehaviour {

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
        health -= amount;
        if(health <= 0f)
        {
            Die();
        } // if
    } // TakeDamage

    void Die()
    {
        // Spawn a shattered object
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Instantiate(priceobject, transform.position, transform.rotation);
        this.sounds[6].Play();
        // Remove the current object
        Destroy(gameObject);
    }


} // Class
