using Models;
using UnityEngine;

namespace MonoBehaviour
{
    public class Test : UnityEngine.MonoBehaviour
    {
        private void Start()
        {
            //ColliderTest();
        }

        // Testing of Collider point changing
        private static void ColliderTest()
        {
            var playerData = new PlayerData
            {
                StartPosition = new UniVector2(),
                StartDirection = new UniVector2(),
                ColliderHeight = 1,
                ColliderLength = 4,
                Speed = 5f,
                YLimit = 4f
            };
            var playerModel = new PlayerModel(playerData, null);
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