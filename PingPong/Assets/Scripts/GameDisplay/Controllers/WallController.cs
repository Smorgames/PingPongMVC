using GameDisplay.Views;
using Logic.Models;

namespace GameDisplay.Controllers
{
    public class WallController
    {
        private readonly WallModel _model;

        public WallController(WallModel model, UpdateObject updateObject)
        {
            _model = model;

            updateObject.OnUpdate += FrameUpdateTick;
        }

        private void FrameUpdateTick(float frameUpdateTime) => 
            _model.CheckForBallCollision();
    }
}