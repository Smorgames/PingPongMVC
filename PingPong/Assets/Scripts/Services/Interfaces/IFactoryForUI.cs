using UnityEngine;

namespace Services.Interfaces
{
    public interface IFactoryForUI
    {
        void CreateGameUISetup(Vector3 cameraPosition, Game game);
    }
}