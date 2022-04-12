using System;
using Logic.Interfaces;

namespace Logic
{
    public class CollidesObserver
    {
        public Action OnCollisionStart;
        public Action OnCollisionEnd;

        public ITransform2D Observable { get; }
        
        private readonly ICollider _collider;
        private bool _isColliding;

        public CollidesObserver(ICollider collider, ITransform2D observable)
        {
            _collider = collider;
            Observable = observable;
        }

        public void CheckForCollision()
        {
            if (ObservableCollidesWithObject() && !_isColliding)
            {
                _isColliding = true;
                OnCollisionStart?.Invoke();
            }

            if (!ObservableCollidesWithObject() && _isColliding)
            {
                _isColliding = false;
                OnCollisionEnd?.Invoke();
            }
        }

        private bool ObservableCollidesWithObject()
        {
            return Observable.Transform.Position.X >= _collider.Collider.LeftBotPoint.X &&
                   Observable.Transform.Position.X <= _collider.Collider.RightTopPoint.X &&
                   Observable.Transform.Position.Y >= _collider.Collider.LeftBotPoint.Y &&
                   Observable.Transform.Position.Y <= _collider.Collider.RightTopPoint.Y;
        }
    }
}