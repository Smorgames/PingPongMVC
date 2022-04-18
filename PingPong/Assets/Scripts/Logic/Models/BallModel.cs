using Logic.Data;
using Logic.Interfaces;
using Logic.Services;

namespace Logic.Models
{
    public class BallModel : ITransform2D, ICollider
    {
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

        public void SetRandomDirection(Team team)
        {
            var xMultiplayer = team == Team.First ? -1 : 1;
            var x = _math.Random(xMultiplayer * 0.5f, xMultiplayer * 1f);

            var yMultiplayer = _math.Random(0f, 1f) > 0.5f ? -1 : 1;
            var y = _math.Random(yMultiplayer * 0.5f, yMultiplayer * 0.6f);

            var direction = new UniVector2(x, y).Normalize();
            Transform.SetDirection(direction);
        }

        public void SetRandomDirection()
        {
            var team = _math.Random(0f, 1f) > 0.5f ? Team.First : Team.Second;
            SetRandomDirection(team);
        }

        public void SetPosition(UniVector2 position) => 
            Transform.SetPosition(position);
    }
}