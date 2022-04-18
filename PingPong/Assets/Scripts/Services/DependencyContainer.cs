using Logic.Services;
using Services.Interfaces;

namespace Services
{
    public class DependencyContainer
    {
        public readonly IMath Math;
        public readonly IGameFactory GameFactory;
        public readonly IFactoryForUI UIFactory;
        public readonly ISceneLoader SceneLoader;

        public DependencyContainer(IMath math, IGameFactory gameFactory, IFactoryForUI uiFactory, ISceneLoader sceneLoader)
        {
            Math = math;
            GameFactory = gameFactory;
            UIFactory = uiFactory;
            SceneLoader = sceneLoader;
        }
    }
}