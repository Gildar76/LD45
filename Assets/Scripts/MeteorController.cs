using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GildarGaming.LD45
{
    
    public class MeteorController : MonoBehaviour
    {
        public AudioSource meteorAudio;
        public AudioClip hitSOund;
        ParticleSystem ps;
        ParticleSystem.EmissionModule psEmission;
        float maxVelocity = -10f;
        float disableParticleVelocity = -1f;
        Rigidbody2D rb;
        private bool hasCollided;
        bool isDestroying = false;
        float destructionTimer = 30f;
        float timeSinceSpawned = 0f;
        // Start is called before the first frame update
        void Start()
        {
            meteorAudio = GetComponent<AudioSource>();


            rb = GetComponent<Rigidbody2D>();
            ps = GetComponent<ParticleSystem>();
            psEmission = ps.emission;
        }


        // Update is called once per frame
        void Update()
        {
            timeSinceSpawned += Time.deltaTime;
            if (timeSinceSpawned > destructionTimer)
            {
                Destroy(this.gameObject, 2f);
            }

            if (rb.velocity.y < maxVelocity)
            {

                rb.velocity = new Vector2(rb.velocity.x, maxVelocity);

            }
            if (rb.velocity.y > disableParticleVelocity)
            {
                //psEmission.rate = 0;
            }
            else
            {
                //psEmission.rate = 50;
            }
            if (hasCollided && !isDestroying && rb.velocity.SqrMagnitude() < 0.1f)
            {
                isDestroying = true;
                Debug.Log("Destroying");
                Destroy(this.gameObject, 3f);
                MeteorSpawner.spawnCount--;
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Colliding");
            hasCollided = true;
            meteorAudio.PlayOneShot(hitSOund);
        }
    }

}
