using GameDisplay.Views;
using Logic.Models;

namespace GameDisplay.Controllers
{
    public class GateController
    {
        private readonly GateModel _model;

        public GateController(GateModel model, UpdateObject updateObject)
        {
            _model = model;

            updateObject.OnUpdate += FrameUpdateTick;
        }

        private void FrameUpdateTick(float frameUpdateTime) => 
            _model.CheckForBallCollision();
    }
}