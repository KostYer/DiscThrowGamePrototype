
using UnityEngine;

namespace GameLogic
{
    public class DiscMover: MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private DistanceInformationProvider distanceInfo;
        [SerializeField] private float minShootForce = 5f;
        [SerializeField] private float maxShootForce = 15f;
        private float shootForceRatio => distanceInfo.DistanceRatio;
        private Vector3 shootDirection => distanceInfo.DirectionToPlayer;
        private RigidbodyConstraints startingConstrains;
        
        private void Start()
        {
            startingConstrains = rb.constraints;
        }

        public void FreezeMovement()
        {  
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
     
        public void UnFreezeMovement()
        {
            rb.constraints = startingConstrains;
        }

        public void LaunchDisc()
        {
            var shootForce = GetShootForce();
            rb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        }


        private float GetShootForce()
        {
            var force = Mathf.Lerp(minShootForce, maxShootForce, shootForceRatio);
            return force;
        }
    }
}