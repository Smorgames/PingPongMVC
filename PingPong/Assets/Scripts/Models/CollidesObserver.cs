using System;
using Interfaces;

namespace Models
{
    public class CollidesObserver
    {
        public Action OnCollisionStart;
        public Action OnCollisionEnd;

        private readonly ITransform2D _observable;
        private readonly ICollider _collider;
        private bool _isColliding;

        public CollidesObserver(ICollider collider, ITransform2D observable)
        {
            _collider = collider;
            _observable = observable;
        }

        public void CheckForCollision()
        {
            if (ObservableCollidesWithObject() && !_isColliding)
            {
                _isColliding = true;
                OnCollisionStart.Invoke();
            }

            if (!ObservableCollidesWithObject() && _isColliding)
            {
                _isColliding = false;
                OnCollisionEnd.Invoke();
            }
        }

        private bool ObservableCollidesWithObject()
        {
            return _observable.Transform.Position.X >= _collider.Collider.LeftBotPoint.X &&
                   _observable.Transform.Position.X <= _collider.Collider.RightTopPoint.X &&
                   _observable.Transform.Position.Y >= _collider.Collider.LeftBotPoint.Y &&
                   _observable.Transform.Position.Y <= _collider.Collider.RightTopPoint.Y;
        }
    }
}