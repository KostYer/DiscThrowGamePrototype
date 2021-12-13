using System;
using System.Reflection;
using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;
using Pointer = UnityEngine.InputSystem.Pointer;

namespace Input
{
   public class InputProvider : MonoBehaviour
    {
       public event Action<Vector2> OnTap;

        public event Action<Vector2> OnPointerDown;
        public event Action<Vector2> OnPointerMove;
        public event Action<Vector2> OnPointerUp;

        public event Action<DragInfo> OnDragStart;
        public event Action<DragInfo> OnDrag;
        public event Action<DragInfo> OnDragEnd;

        public Vector2 PointerPosition => Pointer.current.position.ReadValue();

        private DragInfo drag;
        private bool isHolding;

        private InputActions input;

        public bool IsEnabled { get; private set; } = false;


        public void Awake()
        {
            input = new InputActions();
            BindInputActionsEvents();
            Enable();
            Debug.Log("Input Awake");
        }

        private void BindInputActionsEvents()
        {
            var actions = input.Gameplay;

            actions.Tap.performed += _ => OnTap?.Invoke(PointerPosition);

            actions.Hold.performed += _ => OnPointerDown?.Invoke(PointerPosition);
            actions.Hold.canceled += _ => OnPointerUp?.Invoke(PointerPosition);
            actions.PointerMove.performed += context => OnPointerMove?.Invoke(context.ReadValue<Vector2>());

            actions.Hold.performed += _ => StartDrag(PointerPosition);
            actions.Hold.canceled += _ => EndDrag(PointerPosition);
            actions.PointerMove.performed += context => TryRegisterDrag(context.ReadValue<Vector2>());
        }

        private void StartDrag(Vector2 startPosition)
        {
            drag = DragInfo.CreateInitialDrag(startPosition);
            OnDragStart?.Invoke(drag);
            isHolding = true;
        }

        private void TryRegisterDrag(Vector2 currentPosition)
        {
            if (!isHolding) return;

            drag = DragInfo.UpdateDrag(drag, currentPosition);
            OnDrag?.Invoke(drag);
        }

        private void EndDrag(Vector2 endPosition)
        {
            isHolding = false;
            OnDragEnd?.Invoke(DragInfo.UpdateDrag(drag, endPosition));
            drag = null;
        }

        public void Enable()
        {
            
            input.Enable();

            IsEnabled = true;
        }

        public void Disable()
        {
            
            input.Disable();
            
            IsEnabled = false;
        }
        
    }
   
}