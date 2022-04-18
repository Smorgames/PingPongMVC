using System;

namespace Logic
{
    public class Transform2D
    {
        public Action OnPositionChanged;
    
        public UniVector2 Position { get; }
        public UniVector2 Direction { get; }
        
        public Transform2D(UniVector2 position, UniVector2 direction)
        {
            Position = position;
            Direction = direction;
        }

        public Transform2D(UniVector2 position)
        {
            Position = position;
            Direction = new UniVector2();
        }

        public void SetPosition(UniVector2 position)
        {
            Position.SetCoordinates(position);
            OnPositionChanged?.Invoke();
        }

        public void SetDirection(UniVector2 direction) => 
            Direction.SetCoordinates(direction);
    }
}