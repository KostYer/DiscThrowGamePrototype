using System.Collections;
using System.Collections.Generic;
using GameInput;
using UnityEngine;

namespace Interaction
{
    public class InteractionHandler : MonoBehaviour
    {   
        
       
        [SerializeField] private LayerMask layermask;

        private Camera mainCamera;

        void Start()
        {
            mainCamera = Camera.main;

           
        }

        private void OnDragStart(Vector3 pointerPosition)
        {
            var ray = mainCamera.ScreenPointToRay(pointerPosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, layermask))
            {
                

            }

        }

        private void OnDrag(Vector3 pointerPosition)
        {
        }

        private void OnDragEnd(Vector3 pointerPosition)
        {
        }


        void Update()
        {
        }
/*
        private bool TryGetMosuePositionWorldSpace(out Vector3 worldPos)
        {  
            var isPositionFound = false;
            worldPos = Vector3.zero;
            var mousePosition = Input.mousePosition;
            var ray = mainCamera.ScreenPointToRay(mousePosition);


            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, layermask))
            {
                isPositionFound = true;
                worldPos = hit.point;
            }

            return isPositionFound;
        }
        */
    }
}