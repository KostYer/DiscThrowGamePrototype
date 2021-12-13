using UnityEngine;

namespace Input
{
    public class DragInfo
    {
        public Vector2 StartPosition { get; }

        public Vector2 PreviousPosition { get; }

        public Vector2 CurrentPosition { get; }

        public Vector2 Delta { get; }

        public Vector2 OverallDelta => CurrentPosition - StartPosition;

        public DragInfo(Vector2 currentPosition, Vector2 previousPosition, Vector2 startPosition)
        {
            CurrentPosition = currentPosition;
            PreviousPosition = previousPosition;
            StartPosition = startPosition;

            Delta = CurrentPosition - PreviousPosition;
        }


        public static DragInfo CreateInitialDrag(Vector2 startPosition)
        {
            return new DragInfo(startPosition, startPosition, startPosition);
        }

        public static DragInfo UpdateDrag(DragInfo drag, Vector2 сurrentPosition)
        {
            return new DragInfo(сurrentPosition, drag.CurrentPosition, drag.StartPosition);
        }
        
        public override string ToString()
        {
            return $"(DragInfo) start position: {StartPosition}, " +
                   $"previous position: {PreviousPosition}, " +
                   $"current position: {CurrentPosition}, " +
                   $"delta: {Delta}, " +
                   $"overall delta: {OverallDelta}";
        }
    }
}