using Interfaces;

public class SquareCollider
{
    public UniVector2 LeftBotPoint =>
        new UniVector2(TransformableX() - _size.X / 2, TransformableY() - _size.Y / 2);
    public UniVector2 RightTopPoint =>
        new UniVector2(TransformableX() + _size.X / 2, TransformableY() + _size.Y / 2);

    private readonly UniVector2 _size;
    private readonly ITransform2D _transformable;

    public SquareCollider(float length, float height, ITransform2D transformable)
    {
        _size = new UniVector2(length, height);
        _transformable = transformable;
    }

    private float TransformableX() => _transformable.Transform.Position.X;
    private float TransformableY() => _transformable.Transform.Position.Y;
}