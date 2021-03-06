using Interfaces;
using Services;

namespace Models
{
    public class PlayerModel : ITransform2D, ICollider
    {
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        private readonly IMathService _math;
        private readonly CollidesObserver _collidesObserver;
        private readonly float _speed;
        private readonly float _yLimit;

        public PlayerModel(PlayerData data, IMathService math)
        {
            _math = math;
            _speed = data.Speed;
            _yLimit = data.YLimit;
            Transform = new Transform2D(data.StartPosition, data.StartDirection);
            Collider = new SquareCollider(data.ColliderLength, data.ColliderHeight, this);
            //_collidesObserver = new CollidesObserver(this, ball);
            //_collidesObserver.OnCollisionStart += BallCollidesPlayer;
        }

        public void MovePosition(int yDirection, float frameUpdateDelta)
        {
            Transform.SetDirection(new UniVector2(0f, yDirection));
            var newPosition = Transform.Direction * _speed * frameUpdateDelta + Transform.Position;
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
            
        }

        private UniVector2 ClampPositionByY(UniVector2 position)
        {
            if (_math.Abs(position.Y) >= _yLimit)
            {
                var yValue = position.Y > 0 ? _yLimit : -_yLimit;
                position.SetCoordinates(position.X, yValue);
            }
            
            return position;
        }
    }
}