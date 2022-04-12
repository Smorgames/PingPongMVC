using Logic.Data;
using Logic.Interfaces;
using Logic.Services;

namespace Logic.Models
{
    public class PlayerModel : ITransform2D, ICollider
    {
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        private readonly IMathService _math;
        private readonly CollidesObserver _collidesObserver;
        private readonly PlayerData _data;

        public PlayerModel(PlayerData data, ITransform2D ball, IMathService math)
        {
            _data = data;
            _math = math;
            Transform = new Transform2D(data.StartPosition, data.StartDirection);
            Collider = new SquareCollider(data.ColliderSize.X, data.ColliderSize.Y, this);
            _collidesObserver = new CollidesObserver(this, ball);
            _collidesObserver.OnCollisionStart += BallCollidesPlayer;
        }

        public void MovePosition(int yDirection, float frameUpdateTick)
        {
            Transform.SetDirection(new UniVector2(0f, yDirection));
            var newPosition = Transform.Direction * _data.Speed * frameUpdateTick + Transform.Position;
            var clampedPosition = ClampPositionByY(newPosition);
            Transform.SetPosition(clampedPosition);
        }

        public void SetPosition(UniVector2 position)
        {
            var clampedPosition = ClampPositionByY(position);
            Transform.SetPosition(clampedPosition);
        }

        public void FrameUpdateTick() => 
            _collidesObserver.CheckForCollision();

        private void BallCollidesPlayer()
        {
            var direction = _collidesObserver.Observable.Transform.Direction;
            var newDirection = new UniVector2(-direction.X, direction.Y);
            _collidesObserver.Observable.Transform.SetDirection(newDirection);
        }

        private UniVector2 ClampPositionByY(UniVector2 position)
        {
            if (_math.Abs(position.Y) >= _data.YLimit)
            {
                var yValue = position.Y > 0 ? _data.YLimit : -_data.YLimit;
                position.SetCoordinates(position.X, yValue);
            }
            
            return position;
        }
    }
}