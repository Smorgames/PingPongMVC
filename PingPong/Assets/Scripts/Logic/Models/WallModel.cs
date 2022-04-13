using Logic.Data;
using Logic.Interfaces;

namespace Logic.Models
{
    public class WallModel : ITransform2D, ICollider
    {
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        private readonly CollidesObserver _collidesObserver;

        public WallModel(WallData wallData, ITransform2D ball)
        {
            Transform = new Transform2D(wallData.StartPosition, wallData.StartDirection);
            Collider = new SquareCollider(wallData.ColliderSize.X, wallData.ColliderSize.Y, this);
            _collidesObserver = new CollidesObserver(this, ball);
            _collidesObserver.OnCollisionStart += BallCollidesWithWall;
        }

        private void BallCollidesWithWall()
        {
            var direction = _collidesObserver.Observable.Transform.Direction;
            var newDirection = new UniVector2(-direction.X, direction.Y);
            _collidesObserver.Observable.Transform.SetDirection(newDirection);
        }
    }
}