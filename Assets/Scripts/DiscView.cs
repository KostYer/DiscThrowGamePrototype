using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class DiscView : MonoBehaviour
    {
        [SerializeField] private ArrowDrawer arrowDrawer;

        [SerializeField] private DiscMover discMover;

        [SerializeField] private DistanceInformationProvider distanceInfo;
        [SerializeField] private ParticleSystem deathParticles;

        public void HandleDiscCatch(Transform catcher)
        {
            distanceInfo.Player = catcher;
            discMover.FreezeMovement();
            arrowDrawer.EnableArrow();
        }

        public void HandleDiscRelease()
        {
            DisableArrow();
            LaunchDisc();
            distanceInfo.Reset();
        }


        private void DisableArrow()
        {
            arrowDrawer.DisableArrow();
        }

        private void LaunchDisc()
        {
            discMover.UnFreezeMovement();
            discMover.LaunchDisc();
        }

        public void Die()
        {
            PlayDeathParticles();
        }

        private void PlayDeathParticles()
        {
            deathParticles.transform.SetParent(null);
            deathParticles.Play();
            Destroy(deathParticles.gameObject, 2f);
        }
    }
}