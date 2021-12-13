using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float rotationSpeed = 1f;
        
        
        
        public void LookAt(Vector3 direction)
        {
            
            direction.Normalize();
            var faceDirection = new Vector3(direction.x, rb.position.y, direction.z);

            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(faceDirection), rotationSpeed);
        }
        
        
        public void LookAtInstantly(Vector3 direction)
        {
            
            direction.Normalize();
            var faceDirection = new Vector3(direction.x, rb.position.y, direction.z);

            rb.rotation =  Quaternion.LookRotation(faceDirection) ;
        }

    }
}