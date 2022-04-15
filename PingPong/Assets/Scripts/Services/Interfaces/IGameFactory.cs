using GameDisplay.Views;
using Logic.Data;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;

namespace Services.Interfaces
{
    public interface IGameFactory
    {
        void CreateWall(WallData data, ITransform2D ball, UpdateObject updateObject);
        UpdateObject CreateUpdateObject();
        PlayerModel CreatePlayer(PlayerData data, IMath math, ITransform2D ball);
        BallModel CreateBall(BallData data, IMath math);
        GateModel CreateGate(GateData data, ITransform2D ball, UpdateObject updateObject);
        void CreateBackground();
    }
}