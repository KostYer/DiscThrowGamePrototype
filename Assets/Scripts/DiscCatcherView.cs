using System;
using System.Collections;
using System.Threading.Tasks;
using DefaultNamespace;
using Input;
using Interactions;
using UnityEngine;


namespace GameLogic
{
    public class DiscCatcherView : MonoBehaviour
    {
        [SerializeField] private TriggerSource triggerSource;
        [SerializeField] private PlayerMovementController playerMovement;
        [SerializeField] private float aimingSpeedMultiplier = 0.6f;
        [SerializeField] private float colliderReactivationDelay;
        
        private InputProvider inputProvider;
        private DiscView catchedDisc = null;
        private Coroutine rotationCoroutine = default;
        
        
        private void Start()
        {   inputProvider = GetComponentInParent<InputProvider>();
            triggerSource.OnEnter += OnDiskCollision;
        }


        private void OnDiskCollision(Collider disc)
        {
            triggerSource.OnEnter -= OnDiskCollision;
            inputProvider.OnDragEnd += OnDragEnd;
            catchedDisc = disc.GetComponent<DiscView>();
            catchedDisc.HandleDiscCatch(transform);
            playerMovement.ChangeMovementSpeed(aimingSpeedMultiplier);
        }


        private IEnumerator ReactivateInteractionCollider()
        {
            yield return new WaitForSeconds(colliderReactivationDelay);
            triggerSource.OnEnter += OnDiskCollision;
        }


        private void OnDragEnd(DragInfo context)
        {
            catchedDisc.HandleDiscRelease();
            catchedDisc = null;
            GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
            StartCoroutine(ReactivateInteractionCollider());
            playerMovement.ResetSpeed();
            inputProvider.OnDragEnd -= OnDragEnd;
        }
    }
}