using UnityEngine;

namespace Services
{
    public class MathService : IMathService
    {
        public float Abs(float number) => Mathf.Abs(number);
        public float Random(float min, float max) => UnityEngine.Random.Range(min, max);
    }
}