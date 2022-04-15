using Logic;
using Logic.Data;
using Logic.Services;
using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            var config = new Config();
            
            IMath math = new Math();
            UniVector2.InitMathService(math);

            IAssetProvider assetProvider = new AssetProvider();
            IGameFactory gameFactory = new GameFactory(assetProvider);
            IFactoryForUI uiFactory = new FactoryForUI(assetProvider);

            var container = new DependencyContainer(math, gameFactory, uiFactory);
            var game = new Game(container, config);
        }
    }
}
