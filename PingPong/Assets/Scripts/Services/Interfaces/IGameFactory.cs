using Logic.Interfaces;
using Logic.Models;
using Logic.Services;

namespace Services.Interfaces
{
    public interface IGameFactory
    {
        PlayerModel CreatePlayer(IMathService math, ITransform2D ball);
        BallModel CreateBall(IMathService math);
    }
}