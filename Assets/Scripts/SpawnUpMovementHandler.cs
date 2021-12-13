using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class SpawnUpMovementHandler : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;

        [SerializeField] private float negativeOffsetY = 0.5f;
        
        public void MakeMovingUpEffect(Transform movable)
        {
            var startPosition = movable.localPosition;
            startPosition.y -= negativeOffsetY + movable.localScale.y;
            movable.localPosition = startPosition;
            StartCoroutine(RiseUp(movable));
        }


        private IEnumerator RiseUp(Transform movable)
        {
            var timeLeft = duration;
            while (timeLeft >= 0f)
            {
                timeLeft -= Time.deltaTime;
                movable.localPosition = Vector3.Lerp(movable.localPosition, Vector3.zero, 1 - timeLeft / duration);
                yield return null;
            }
          
        }

    }
}