using Services;

public class UniVector2
{
    private const float EqualThreshold = 0.00001f;
    private static IMathService _math;

    public float X { get; private set; }
    public float Y { get; private set; }

    public UniVector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public UniVector2()
    {
        X = 0f;
        Y = 0f;
    }

    public static void InitMathService(IMathService mathService) => 
        _math ??= mathService;

    public void SetCoordinates(UniVector2 coordinates) => 
        SetCoordinates(coordinates.X, coordinates.Y);

    public void SetCoordinates(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static UniVector2 operator +(UniVector2 a, UniVector2 b) =>
        new UniVector2(a.X + b.X, a.Y + b.Y);
    public static UniVector2 operator *(UniVector2 a, float b) =>
        new UniVector2(a.X * b, a.Y * b);
    public static bool operator ==(UniVector2 a, UniVector2 b) => 
        _math.Abs(a.X - b.X) <= EqualThreshold && _math.Abs(a.Y - b.Y) <= EqualThreshold;
    public static bool operator !=(UniVector2 a, UniVector2 b) => 
        !(a == b);

    public override string ToString() => $"({X}; {Y})";
}