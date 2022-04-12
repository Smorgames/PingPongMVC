using Logic.Data;
using Logic.Interfaces;
using Logic.Services;

namespace Logic.Models
{
    public class BallModel : ITransform2D, ICollider
    {
        private const float MinRandomDirection = -1f;
        private const float MaxRandomDirection = 1f;
        
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        private readonly IMathService _math;
        private readonly float _speed;

        public BallModel(BallData data, IMathService math)
        {
            _math = math;
            _speed = data.Speed;
            Transform = new Transform2D(data.StartPosition, data.StartDirection);
            Collider = new SquareCollider(data.ColliderSize.X, data.ColliderSize.Y, this);
        }

        public void MovePosition(float frameUpdateTick)
        {
            var newPosition = Transform.Direction * _speed * frameUpdateTick + Transform.Position;
            Transform.SetPosition(newPosition);
        }

        public void SetRandomDirection()
        {
            var x = _math.Random(MinRandomDirection, MaxRandomDirection);
            var y = _math.Random(MinRandomDirection, MaxRandomDirection);
            var direction = new UniVector2(x, y).Normalize();
            SetDirection(direction);
        }
        
        public void SetDirection(UniVector2 direction) => 
            Transform.SetDirection(direction);
    }
}