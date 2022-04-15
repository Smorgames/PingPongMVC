using Logic.Data;
using Logic.Interfaces;
using Logic.Services;

namespace Logic.Models
{
    public class BallModel : ITransform2D, ICollider
    {
        private const float XRandomDirection = 1f;
        private const float YRandomDirection = 0.25f;
        
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        private readonly IMath _math;
        private readonly float _speed;

        public BallModel(BallData data, IMath math)
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
            var x = _math.Random(-XRandomDirection, XRandomDirection);
            var y = _math.Random(-YRandomDirection, YRandomDirection);
            var direction = new UniVector2(x, y).Normalize();
            Transform.SetDirection(direction);
        }

        public void SetPosition(UniVector2 position) => 
            Transform.SetPosition(position);
    }
}