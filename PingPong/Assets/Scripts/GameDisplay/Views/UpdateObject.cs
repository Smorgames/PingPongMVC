using System;
using UnityEngine;

namespace GameDisplay.Views
{
    public class UpdateObject : MonoBehaviour
    {
        public Action<float> OnUpdate;

        private void Update() => 
            OnUpdate?.Invoke(Time.deltaTime);
    }
}