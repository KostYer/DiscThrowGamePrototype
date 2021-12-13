using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class ArrowDrawer : MonoBehaviour
    {
        [SerializeField] private RectTransform arrowHolder;
        [SerializeField] private float maxScale;
        [SerializeField] private DistanceInformationProvider distanceInfo;
        private float drawRatio => distanceInfo.DistanceRatio;
        private Vector3 arrowLookDirection => distanceInfo.DirectionToPlayer;
        private Vector3 startingArrowScale;


        private Coroutine scalingCoroutine = default;
        private Coroutine rotationCoroutine = default;


        public void EnableArrow()
        {
            startingArrowScale = arrowHolder.localScale;
            ScaleArrow();
            RotateArrow();
        }

        public void ScaleArrow()
        {
            arrowHolder.gameObject.SetActive(true);
            scalingCoroutine = StartCoroutine(ScaleArrowCoroutine());
        }

        private IEnumerator ScaleArrowCoroutine()
        {
            while (true)
            {
                var scaleDelta = Mathf.Lerp(0f, maxScale, drawRatio);
                arrowHolder.localScale = startingArrowScale * scaleDelta;

                yield return null;
            }
        }

        public void RotateArrow()
        {
            rotationCoroutine = StartCoroutine(RotateArrowCoroutine());
        }


        private IEnumerator RotateArrowCoroutine()
        {
            while (true)
            {
                arrowHolder.transform.forward = arrowLookDirection;
                yield return null;
            }
        }


        public void DisableArrow()
        {
            arrowHolder.gameObject.SetActive(false);
            arrowHolder.localScale = startingArrowScale;
            arrowHolder.localRotation = Quaternion.identity;
            StopCoroutine(rotationCoroutine);
            StopCoroutine(scalingCoroutine);
        }




        private void OnDrawGizmos()
        {
            
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, arrowHolder.transform.forward * 10f);
        }
    }
}