using UnityEngine;

namespace Services
{
    public interface IFactoryForUI
    {
        void CreateGameUISetup(Vector3 cameraPosition, Game game);
    }
}