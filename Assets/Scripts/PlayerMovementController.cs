using Input;
using UnityEngine;

namespace GameLogic
{
    public class PlayerMovementController : MonoBehaviour
    {
      

        [SerializeField] private UnitMovement movement;
        private InputProvider inputProvider;

        private float divider = 150;

        private float threshold = 10f;

        public Vector2 Direction => Distance <= threshold ? Vector2.zero : (Position - StartPosition).normalized;

        public float Distance => (Position - StartPosition).magnitude;

        public Vector2 StartPosition { get; private set; }

        public Vector2 Position { get; private set; }


        private void Start()
        {
            inputProvider = GetComponentInParent<InputProvider>();
            inputProvider.OnDragStart += OnDragStart;
            inputProvider.OnDrag += OnDrag;
            inputProvider.OnDragEnd += OnDragEnd;
        }

        private void OnDragStart(DragInfo context)
        {
            StartPosition = Position = context.StartPosition;
        }

        private void OnDrag(DragInfo context)
        {
            Position = context.CurrentPosition;
            var delta = Position - StartPosition;
            delta = Vector2.ClampMagnitude(delta, divider);
            Position = StartPosition + delta;
            var direction = Direction * Distance / divider;
            movement.DesiredDirection = new Vector3(direction.x, 0, direction.y);
            movement.EnableMovement();
        }

        private void OnDragEnd(DragInfo context)
        {
            movement.DesiredDirection = Vector3.zero;
            movement.DisableMovement();
        }

        public void ResetSpeed()
        {
            movement.ResetMovementSpeed();
        }

        public void ChangeMovementSpeed(float percent)
        {
            movement.ChangeMovementSpeed(percent);
        }


        private void OnDestroy()
        {
            inputProvider.OnDragStart -= OnDragStart;
            inputProvider.OnDrag -= OnDrag;
            inputProvider.OnDragEnd -= OnDragEnd;
        }
    }
}