using System;
using UnityEngine;

namespace View
{
    public class PlayerView : UnityEngine.MonoBehaviour
    {
        private const int UpDirection = 1;
        private const int DownDirection = -1;
        
        public Action<int, float> OnMoveRequest;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
                OnMoveRequest?.Invoke(UpDirection, Time.deltaTime);
            
            if (Input.GetKey(KeyCode.S))
                OnMoveRequest?.Invoke(DownDirection, Time.deltaTime);
        }

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();
    }
}