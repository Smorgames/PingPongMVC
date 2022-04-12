using Interfaces;

namespace Models
{
    public class BallModel : ITransform2D, ICollider
    {
        public Transform2D Transform { get; }
        public SquareCollider Collider { get; }

        public BallModel(UniVector2 startPosition, UniVector2 colSize)
        {
            Transform = new Transform2D(startPosition, new UniVector2());
            Collider = new SquareCollider(colSize.X, colSize.Y, this);
        }
    }
}