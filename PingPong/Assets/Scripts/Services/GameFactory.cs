using GameDisplay.Controllers;
using GameDisplay.Views;
using Logic;
using Logic.Data;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using Services.Interfaces;
using Tools;
using UnityEngine;

namespace Services
{
    public class GameFactory : IGameFactory
    {
        private const string PlayerPath = "Player";
        private const string BallPath = "Ball";
        private const string CameraPath = "Camera";

        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public PlayerModel CreatePlayer(IMathService math, ITransform2D ball)
        {
            var playerData = new PlayerData
            {
                StartPosition = new UniVector2(5f, 0f),
                StartDirection = new UniVector2(),
                ColliderSize = new UniVector2(1f, 1f),
                Speed = 10f,
                YLimit = 4f
            };
            var model = new PlayerModel(playerData, ball, math);
            var pref = _assetProvider.LoadAsset<PlayerView>(PlayerPath);
            var view = Object.Instantiate(pref, playerData.StartPosition.ToVector2(), Quaternion.identity);
            var unused = new PlayerController(model, view);
            return model;
        }

        public BallModel CreateBall(IMathService math)
        {
            var ballData = new BallData
            {
                StartPosition = new UniVector2(),
                StartDirection = new UniVector2(),
                ColliderSize = new UniVector2(1f, 1f),
                Speed = 5f
            };

            var model = new BallModel(ballData, math);
            var pref = _assetProvider.LoadAsset<BallView>(BallPath);
            var view = Object.Instantiate(pref, ballData.StartPosition.ToVector2(), Quaternion.identity);
            var unused = new BallController(model, view);
            model.SetRandomDirection();
            return model;
        }

        public Camera CreateCamera(Vector3 position)
        {
            var pref = _assetProvider.LoadAsset<Camera>(CameraPath);
            return Object.Instantiate(pref, position, Quaternion.identity);
        }
    }
}