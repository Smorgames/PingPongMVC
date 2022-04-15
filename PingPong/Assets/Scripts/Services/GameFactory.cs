using GameDisplay.Controllers;
using GameDisplay.Views;
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
        private const string UpdateObjectName = "UpdateObject";
        
        private const string PlayerPath = "Player";
        private const string BallPath = "Ball";
        private const string BackgroundPath = "Background";

        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public PlayerModel CreatePlayer(PlayerData data, IMath math, ITransform2D ball)
        {
            var model = new PlayerModel(data, ball, math);
            var pref = _assetProvider.LoadAsset<PlayerView>(PlayerPath);
            var view = Object.Instantiate(pref, data.StartPosition.ToVector2(), Quaternion.identity);
            var unused = new PlayerController(model, view);
            return model;
        }

        public BallModel CreateBall(BallData data, IMath math)
        {
            var model = new BallModel(data, math);
            var pref = _assetProvider.LoadAsset<BallView>(BallPath);
            var view = Object.Instantiate(pref, data.StartPosition.ToVector2(), Quaternion.identity);
            var unused = new BallController(model, view);
            model.SetRandomDirection();
            return model;
        }

        public UpdateObject CreateUpdateObject()
        {
            var updateObject = new GameObject(UpdateObjectName);
            return updateObject.AddComponent<UpdateObject>();
        }

        public void CreateWall(WallData data, ITransform2D ball, UpdateObject updateObject)
        {
            var model = new WallModel(data, ball);
            var controller = new WallController(model, updateObject);
        }

        public GateModel CreateGate(GateData data, ITransform2D ball, UpdateObject updateObject)
        {
            var model = new GateModel(data, ball);
            var controller = new GateController(model, updateObject);
            return model;
        }

        public void CreateBackground()
        {
            var pref = _assetProvider.LoadAsset<GameObject>(BackgroundPath);
            Object.Instantiate(pref);
        }
    }
}