using Controllers;
using Models;
using UnityEngine;
using View;

namespace Services
{
    public class GameFactory
    {
        private const string PlayerPath = "Player";
        
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreatePlayer(IMathService math)
        {
            var playerData = new PlayerData
            {
                StartPosition = new UniVector2(),
                StartDirection = new UniVector2(),
                ColliderHeight = 1,
                ColliderLength = 1,
                Speed = 10f,
                YLimit = 4f
            };
            var model = new PlayerModel(playerData, math);
            var pref = _assetProvider.LoadAsset<PlayerView>(PlayerPath);
            var view = Object.Instantiate(pref);
            var controller = new PlayerController(model, view);
        }
    }
}