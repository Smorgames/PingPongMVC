using Services;

namespace MonoBehaviour
{
    public class GameBootstrapper : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            IMathService math = new MathService();
            UniVector2.InitMathService(math);

            IAssetProvider assetProvider = new AssetProvider();
            var gameFactory = new GameFactory(assetProvider);
            
            gameFactory.CreatePlayer(math);
        }
    }
}
