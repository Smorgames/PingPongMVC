using Logic.Services;
using Services.Interfaces;

namespace Services
{
    public class DependencyContainer
    {
        public readonly IMath Math;
        public readonly IGameFactory GameFactory;
        public readonly IFactoryForUI UIFactory;

        public DependencyContainer(IMath math, IGameFactory gameFactory, IFactoryForUI uiFactory)
        {
            Math = math;
            GameFactory = gameFactory;
            UIFactory = uiFactory;
        }
    }
}