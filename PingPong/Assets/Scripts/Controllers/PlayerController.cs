using Models;
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
            View.OnMoveRequest += ViewMoveRequest;
        }

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);

        private void ViewMoveRequest(int yDirection, float frameUpdateDelta) => 
            Model.MovePosition(yDirection, frameUpdateDelta);
    }
}