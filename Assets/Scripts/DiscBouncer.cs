using System;
using Interactions;
using UnityEngine;

namespace GameLogic
{
    public class DiscBouncer: MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        private Vector3 lastFrameVelocity= Vector3.zero;


        private void FixedUpdate()
        {
            lastFrameVelocity = rb.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Bounce(collision.contacts[0].normal);
        }
        
        
        private void Bounce(Vector3 collisionNormal)
        {
            var speed = lastFrameVelocity.magnitude;
            var direction = Vector3.Reflect(lastFrameVelocity.normalized , collisionNormal );
            rb.velocity = direction * speed ;  
        }

    }
}