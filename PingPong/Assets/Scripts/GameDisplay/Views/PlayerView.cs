using System;
using Logic;
using Tools;
using UnityEngine;

namespace GameDisplay.Views
{
    public class PlayerView : MonoBehaviour
    {
        private const int UpDirection = 1;
        private const int DownDirection = -1;
        
        public Action<int, float> OnMoveRequest;
        public Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
            
            if (Input.GetKey(KeyCode.W))
                OnMoveRequest?.Invoke(UpDirection, Time.deltaTime);
            
            if (Input.GetKey(KeyCode.S))
                OnMoveRequest?.Invoke(DownDirection, Time.deltaTime);
        }

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();
    }
}