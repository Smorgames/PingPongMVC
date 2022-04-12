using Logic;
using Logic.Data;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using Services;
using Services.Interfaces;
using Tools;
using UnityEngine;

namespace MonoBehaviours
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            IMathService math = new MathService();
            UniVector2.InitMathService(math);

            IAssetProvider assetProvider = new AssetProvider();
            IGameFactory gameFactory = new GameFactory(assetProvider);

            var ball = gameFactory.CreateBall(math);
            gameFactory.CreatePlayer(math, ball);

            //Tests
            ColliderTest(math, ball);
        }
        
        // Testing of Collider point changing
        private static void ColliderTest(IMathService math, ITransform2D ball)
        {
            var playerData = new PlayerData
            {
                StartPosition = new UniVector2(),
                StartDirection = new UniVector2(),
                ColliderSize = new UniVector2(4, 1),
                Speed = 5f,
                YLimit = 4f
            };
            var playerModel = new PlayerModel(playerData, ball, math);
            // Player position (0; 0)
            // Collider size (4; 1)
            var assert1 = 
                playerModel.Collider.LeftBotPoint == new UniVector2(-2f, -0.5f) && 
                new UniVector2(playerModel.Collider.LeftBotPoint.X, playerModel.Collider.RightTopPoint.Y) == new UniVector2(-2f, 0.5f) && 
                playerModel.Collider.RightTopPoint == new UniVector2(2f, 0.5f) && 
                new UniVector2(playerModel.Collider.RightTopPoint.X, playerModel.Collider.LeftBotPoint.Y) == new UniVector2(2f, -0.5f);
            
            playerModel.SetPosition(new UniVector2(3, 0.5f));
            // Player position (3; 0.5)
            // Collider size (4; 1)
            var assert2 = 
                playerModel.Collider.LeftBotPoint == new UniVector2(1f, 0f) && 
                new UniVector2(playerModel.Collider.LeftBotPoint.X, playerModel.Collider.RightTopPoint.Y) == new UniVector2(1f, 1f) && 
                playerModel.Collider.RightTopPoint == new UniVector2(5f, 1f) && 
                new UniVector2(playerModel.Collider.RightTopPoint.X, playerModel.Collider.LeftBotPoint.Y) == new UniVector2(5f, 0f);

            var assert = assert1 && assert2 ? "[TEST: PASSED]".Color("Green") : "TEST: FAILED".Color("Red");
            
            Debug.Log($"{assert}: Changing the position of the transform and the position of the collider");
        }
    }
}
