using System;
using System.Collections;
using Interactions;
using UnityEngine;

namespace GameLogic
{
    public class GoalKeeperController : MonoBehaviour
    {
        public Transform disc = null;
        [SerializeField] private UnitMovement movement;
        [SerializeField] private float discDetectionRadius = 2f;
        [SerializeField] private TriggerSource triggerSource;
        [SerializeField] private float resetPositionDuration = 0.2f;

        private Coroutine catchDisc = default;
        public event Action OnEnemyCathedDisc;

        private void Start()
        {
            triggerSource.OnEnter += OnDiscCatched;
        }

        private void OnDiscCatched(Collider disc)
        {
            disc.GetComponent<DiscView>().Die();
            OnEnemyCathedDisc?.Invoke();
        }

        public void OnDiscRespawned(Transform disc)
        {
            this.disc = disc;
            catchDisc = StartCoroutine(MoveToDisc());
        }

        private IEnumerator MoveToDisc()
        {
            while (true)
            {
                if (GetDisanceToDisc() <= discDetectionRadius)
                {
                    movement.DesiredDirection = GetDirectionXtoDisc();
                    movement.EnableMovement();
                }
                else
                {             
                    movement.DisableMovement();
                }

                yield return null;
            }
        }

        public void Reset()
        {
            StopCoroutine(catchDisc);
            movement.DisableMovement();
            StartCoroutine(MoveToStartPosition());
        }


        private IEnumerator MoveToStartPosition()
        {
            var timeLeft = resetPositionDuration;
            var currentPosition = transform.localPosition;
            yield return new WaitForSeconds(1.3f);
            while (timeLeft >= 0f)
            {
                timeLeft -= Time.deltaTime;
                transform.localPosition = Vector3.Lerp(currentPosition, Vector3.zero, 1 - timeLeft / resetPositionDuration);
                yield return null;
            }
        }


        public void SpeedUp(float speedUpStep)
        {
            movement.IncreaseMovementSpeed(speedUpStep);
        }


        private Vector3 GetDirectionXtoDisc()
        {
            var direction =disc.transform.position - transform.position;
            direction.z = 0f;
            direction.y = 0f;
            return  direction.normalized;
        }


        private float GetDisanceToDisc()
        {
            return Vector3.Distance(disc.transform.position, transform.position);
        }

        private void OnDestroy()
        {
            triggerSource.OnEnter -= OnDiscCatched;
        }
    }
}