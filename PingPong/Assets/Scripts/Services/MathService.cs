using Logic.Services;
using UnityEngine;

namespace Services
{
    public class MathService : IMathService
    {
        public float Abs(float number) => Mathf.Abs(number);
        public float Sqrt(float number) => Mathf.Sqrt(number);
        public float Random(float min, float max) => UnityEngine.Random.Range(min, max);
    }
}