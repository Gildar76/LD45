using GildarGaming.Ld45;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace GildarGaming.LD45
{
    public class PlayerController : MonoBehaviour
    {
        public AudioClip beamSound;
        public AudioClip deathSound;
        public AudioSource playerAudio;
        Rigidbody2D rb;
        [SerializeField] float speed;
        bool isAlive = true;
        LineRenderer lr;
        GameObject target;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            lr = GetComponent<LineRenderer>();
            playerAudio = GetComponent<AudioSource>();
        }

        void OnEnable()
        {
            GameManager.playerIsDead = false;
        }

        void Update()
        {
            Vector3 pos = transform.position;
            if (pos.x > 475 || pos.x < -250f)
            {
                pos.x = Mathf.Clamp(pos.x, -250f, 475f);
                transform.position = pos;
            }
            if (pos.y > 50)
            {
                pos.y = 50f;
                transform.position = pos;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivateTractorBeam();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                DeActivateTractorBeam();
            }
            if (lr.enabled && target != null)
            {
                DrawTractorBeam();
                
            }

        }
        void FixedUpdate()
        {
            if (lr.enabled && target != null)
            {
                PullTarget();
            }
            Movement();
            
        }

        private void Movement()
        {
            Vector2 movementVector = new Vector2();
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.y = Input.GetAxis("Vertical");
            rb.AddForce(movementVector * speed);
        }

        void DeActivateTractorBeam()
        {
            lr.enabled = false;
        }
        void ActivateTractorBeam()
        {

            target = FindClosestGameObject(transform.position, GameObject.FindGameObjectsWithTag("BuildingParth"));
            if (target == null) return;
            playerAudio.PlayOneShot(beamSound);
            lr.enabled = true;

        }
    
        void DrawTractorBeam()
        {
            lr.positionCount = 2;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, target.transform.position);
            


        }
        void PullTarget()
        {
            var pullDirection = transform.position - target.transform.position;
            target.GetComponent<Rigidbody2D>().AddForce(pullDirection * 2f);
        }
        void Death()
        {
            isAlive = false;
            Destroy(this.gameObject,2f);
            playerAudio.Stop();
            playerAudio.PlayOneShot(deathSound);
            CanvasGroup gr = FindObjectOfType<CanvasGroup>();
            StartCoroutine(FadeScreen(gr));
            TextMeshProUGUI gameoverText = FindObjectOfType<TextMeshProUGUI>();
            gameoverText.text = "YOU HAVE DIED! PRESS SPACE TO RESTART";
            gameoverText.color = Color.red;
            GameManager.playerIsDead = true;
            this.enabled = false;


        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Meteor") || other.gameObject.CompareTag("Ground"))
            {
                Debug.Log("COlliding with ground or meteor");
                Death();
            }
        }

        public static GameObject FindClosestGameObject(Vector3 currentPosition, GameObject[] objectArray, float maxDistance = float.MaxValue)
        {
            maxDistance = 50f;
            float closestDistance = float.MaxValue;
            GameObject closest = null;
            for (int i = 0; i < objectArray.Length; i++)
            {
                if (objectArray[i] == null) continue;
                float currentDistance = Vector3.Distance(currentPosition, objectArray[i].transform.position);
                if (currentDistance < maxDistance && currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    closest = objectArray[i];
                }
            }
            return closest;
        }

        private IEnumerator FadeScreen(CanvasGroup group)
        {
            while (group.alpha < 1)
            {
                yield return group.alpha += Time.deltaTime / 5f; ;
            }

        }
    }

}
