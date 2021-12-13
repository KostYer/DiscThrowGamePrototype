using UnityEngine;

namespace GameLogic
{
    public class DistanceInformationProvider : MonoBehaviour
    {
        public Transform Player { get; set; } = null;

        [SerializeField] private float maxCalcDistance = 6f;

        public float DistanceRatio
        {
            get => Mathf.Clamp(CurrendDistance / maxCalcDistance, 0f, 1f);
        }

        public float CurrendDistance
        {
            get => GetGurrentDistanceToPlayer();
        }

        public Vector3 DirectionToPlayer
        {
            get => GetCurrentDirectionToPlayer();
        }

        public void Reset()
        {
            Player = null;
        }


        private float GetGurrentDistanceToPlayer()
        {
            if (Player == null)
            {
                return 0f;
            }

            var distance = Vector3.Distance(Player.position, transform.position);
            return distance;
        }

        private Vector3 GetCurrentDirectionToPlayer()
        {
            if (Player == null)
            {
                return Vector3.zero;
            }

            var direction = Player.position - transform.position;
            return direction.normalized;
        }
    }
}