using System;
using Logic.Interfaces;

namespace Logic
{
    public class Transform2D
    {
        public Action OnPositionChange;
    
        public UniVector2 Position { get; }
        public UniVector2 Direction { get; }
    
        private ITransform2D _transform;

        public Transform2D(UniVector2 position, UniVector2 direction)
        {
            Position = position;
            Direction = direction;
        }

        public void SetPosition(UniVector2 position)
        {
            Position.SetCoordinates(position);
            OnPositionChange?.Invoke();
        }

        public void SetDirection(UniVector2 direction) => 
            Direction.SetCoordinates(direction);
    }
}