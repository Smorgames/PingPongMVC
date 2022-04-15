using GameDisplay;
using GameDisplay.Controllers;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services
{
    public class FactoryForUI : IFactoryForUI
    {
        private const string CameraPath = "UI/Camera";
        private const string EventSystemPath = "UI/EventSystem";
        private const string CanvasPath = "UI/Canvas";
        
        private readonly IAssetProvider _assetProvider;

        public FactoryForUI(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateGameUISetup(Vector3 cameraPosition, Game game)
        {
            var camera = CreateCamera(cameraPosition);
            CreateEventSystem();

            var canvas = CreateCanvas(camera);
            var scoreDisplayView = canvas.GetComponentInChildren<ScoreDisplayView>();
            var scoreDisplayController = new ScoreDisplayController(scoreDisplayView, game);
        }

        private Camera CreateCamera(Vector3 position)
        {
            var pref = _assetProvider.LoadAsset<Camera>(CameraPath);
            return Object.Instantiate(pref, position, Quaternion.identity);
        }

        private Canvas CreateCanvas(Camera camera)
        {
            var pref = _assetProvider.LoadAsset<Canvas>(CanvasPath);
            var canvas = Object.Instantiate(pref);
            canvas.worldCamera = camera;
            return canvas;
        }

        private void CreateEventSystem()
        {
            var pref = _assetProvider.LoadAsset<EventSystem>(EventSystemPath);
            Object.Instantiate(pref);
        }
    }
}