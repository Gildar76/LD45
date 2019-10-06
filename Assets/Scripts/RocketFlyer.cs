using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlyer : MonoBehaviour
{
    public AudioSource rocketAudio;
    public AudioClip thrustSound;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    void OnEnable()
    {
        rocketAudio.PlayOneShot(thrustSound);
        rb = gameObject.AddComponent<Rigidbody2D>();
    }

     void FixedUpdate()
    {
        rb.AddForce(Vector3.up * 15f);
    }
}
