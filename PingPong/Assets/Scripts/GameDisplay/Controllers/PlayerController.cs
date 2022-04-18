using GameDisplay.Views;
using Logic.Models;

namespace GameDisplay.Controllers
{
    public class PlayerController
    {
        public PlayerModel Model { get; }
        public PlayerView View { get; }

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            Model = playerModel;
            View = playerView;
            View.SetTeam(Model.MyTeam);

            Subscriptions();
        }

        private void Subscriptions()
        {
            Model.Transform.OnPositionChanged += ModelPositionChanged;
            View.OnUpdate += ViewUpdateTick;
            View.OnMoveRequest += ViewMoveRequest;
        }

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);

        private void ViewUpdateTick() => 
            Model.CheckForBallCollision();

        private void ViewMoveRequest(int yDirection, float frameUpdateTick) => 
            Model.MovePosition(yDirection, frameUpdateTick);
    }
}