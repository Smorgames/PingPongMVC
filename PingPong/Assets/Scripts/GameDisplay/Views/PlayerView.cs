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

        private Team _team;

        private void Update()
        {
            OnUpdate?.Invoke();
            
            if (_team == Team.First && Input.GetKey(KeyCode.W))
                OnMoveRequest?.Invoke(UpDirection, Time.deltaTime);
            
            if (_team == Team.First && Input.GetKey(KeyCode.S))
                OnMoveRequest?.Invoke(DownDirection, Time.deltaTime);
            
            if (_team == Team.Second && Input.GetKey(KeyCode.UpArrow))
                OnMoveRequest?.Invoke(UpDirection, Time.deltaTime);
            
            if (_team == Team.Second && Input.GetKey(KeyCode.DownArrow))
                OnMoveRequest?.Invoke(DownDirection, Time.deltaTime);
        }

        public void SetPosition(UniVector2 position) => 
            transform.position = position.ToVector2();

        public void SetTeam(Team team) => 
            _team = team;
    }
}