using System;
using Logic;
using Tools;
using UnityEngine;

namespace GameDisplay.Views
{
    public class BallView : MonoBehaviour
    {
        public Action<float> OnMoveRequest;

        private void Update() => 
            OnMoveRequest?.Invoke(Time.deltaTime);

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();
    }
}