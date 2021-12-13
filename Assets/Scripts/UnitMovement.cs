 
using System;
using UnityEngine;

namespace GameLogic
{
    public class UnitMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float initialMovementSpeed;
        private float movementSpeed;
        public Vector3 DesiredDirection{ get; set; }
  
        private bool canMove = false;

        private Vector3 direction;

        private void Start()
        {
            ResetMovementSpeed();
        }

        public void EnableMovement()
        {   
            if (!canMove)
            canMove = true;
        }

        public void DisableMovement()
        {
            canMove = false;
            DesiredDirection = Vector3.zero;
            rb.velocity= Vector3.zero;
        }


        private void FixedUpdate()
        {
            

           if (canMove)
           {
              // transform.Translate(DesiredDirection * movementSpeed * Time.fixedDeltaTime);
              rb.velocity = DesiredDirection * movementSpeed *100* Time.fixedDeltaTime;
           }
        }

        public void IncreaseMovementSpeed(float step)
        {
            movementSpeed += step;
        }
        public void ResetMovementSpeed()
        {
            movementSpeed = initialMovementSpeed;
        }
        
        
        public void ChangeMovementSpeed(float percent)
        {
            movementSpeed *= percent;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position,DesiredDirection * movementSpeed  );
        }
    }
}