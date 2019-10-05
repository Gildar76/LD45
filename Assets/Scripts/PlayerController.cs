using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GildarGaming.LD45
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb;
        [SerializeField] float speed;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

        }


        void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector2 movementVector = new Vector2();
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.y = Input.GetAxis("Vertical");
            rb.AddForce(movementVector * speed);
        }
    }

}
