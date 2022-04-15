using System;
using Logic.Data;
using Logic.Interfaces;

namespace Logic.Models
{
    public class GateModel : ITransform2D, ICollider
    {
        public Action<Team> OnGoal;
        
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        private readonly CollidesObserver _collidesObserver;
        private readonly Team _team;

        public GateModel(GateData data, ITransform2D ball)
        {
            Transform = new Transform2D(data.StartPosition);
            Collider = new SquareCollider(data.ColliderSize.X, data.ColliderSize.Y, this);
            _team = data.Team;
            _collidesObserver = new CollidesObserver(this, ball);
            _collidesObserver.OnCollisionStart += BallCollidesWithGate;
        }

        public void CheckForBallCollision() => 
            _collidesObserver.CheckForCollision();

        private void BallCollidesWithGate() => 
            OnGoal?.Invoke(_team);
    }
}