using GameDisplay.Views;
using Logic.Models;

namespace GameDisplay.Controllers
{
    public class BallController
    {
        public BallModel Model { get; }
        public BallView View { get; }

        public BallController(BallModel model, BallView view)
        {
            Model = model;
            View = view;
            
            Subscriptions();
        }

        private void Subscriptions()
        {
            Model.Transform.OnPositionChange += ModelPositionChanged;
            View.OnMoveRequest += ViewMoveRequest;
        }

        private void ModelPositionChanged() => 
            View.SetPosition(Model.Transform.Position);

        private void ViewMoveRequest(float frameUpdateTick)
        {
            Model.MovePosition(frameUpdateTick);
        }
    }
}