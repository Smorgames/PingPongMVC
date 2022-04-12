﻿using Logic.Models;
using View;

namespace Controllers
{
    public class PlayerController
    {
        public PlayerModel Model { get; }
        public PlayerView View { get; }

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            Model = playerModel;
            View = playerView;

            Subscriptions();
        }

        private void Subscriptions()
        {
            Model.Transform.OnPositionChange += ModelPositionChanged;
            View.OnUpdate += ViewUpdateTick;
            View.OnMoveRequest += ViewMoveRequest;
        }

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);

        private void ViewUpdateTick() => 
            Model.FrameUpdateTick();

        private void ViewMoveRequest(int yDirection, float frameUpdateTick) => 
            Model.MovePosition(yDirection, frameUpdateTick);
    }
}