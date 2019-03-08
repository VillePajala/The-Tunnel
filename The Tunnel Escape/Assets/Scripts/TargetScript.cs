
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public GameObject destroyedVersion;
    public GameObject priceobject;
    public float health = 50f;
    private AudioSource[] sounds = null;

    void Start() {
        this.sounds = GameObject.Find("AudioController").GetComponents<AudioSource>();
    }

    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0f) {
            Die();
        } 
    } 

    void Die() {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Instantiate(priceobject, transform.position, transform.rotation);
        this.sounds[6].Play();
        Destroy(gameObject);
    } 

} 
