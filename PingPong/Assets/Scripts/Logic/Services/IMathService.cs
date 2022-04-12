namespace Logic.Services
{
    public interface IMathService
    {
        float Abs(float number);
        float Sqrt(float number);
        float Random(float min, float max);
    }
}