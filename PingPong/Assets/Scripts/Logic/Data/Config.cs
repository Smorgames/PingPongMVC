namespace Logic.Data
{
    public class Config
    {
        public readonly BallData Ball = new BallData
        {
            StartPosition = new UniVector2(),
            StartDirection = new UniVector2(),
            ColliderSize = new UniVector2(1f, 1f),
            Speed = 5f
        };

        public readonly PlayerData FirstPlayer = new PlayerData
        {
            Team = Team.First,
            StartPosition = new UniVector2(-8f, 0f),
            StartDirection = new UniVector2(),
            ColliderSize = new UniVector2(0.5f, 2f),
            Speed = 10f,
            YLimit = 4f
        };
        
        public readonly PlayerData SecondPlayer = new PlayerData
        {
            Team = Team.Second,
            StartPosition = new UniVector2(8f, 0f),
            StartDirection = new UniVector2(),
            ColliderSize = new UniVector2(0.5f, 2f),
            Speed = 10f,
            YLimit = 4f
        };

        public readonly WallData FirstWall = new WallData
        {
            StartPosition = new UniVector2(0f, 5.5f),
            ColliderSize = new UniVector2(24f, 1f)
        };
        
        public readonly WallData SecondWall = new WallData
        {
            StartPosition = new UniVector2(0f, -5.5f),
            ColliderSize = new UniVector2(24f, 1f)
        };

        public readonly GateData FirstGate = new GateData
        {
            StartPosition = new UniVector2(-10f, 0f),
            ColliderSize = new UniVector2(1f, 10f),
            Team = Team.First
        };
        
        public readonly GateData SecondGate = new GateData
        {
            StartPosition = new UniVector2(10f, 0f),
            ColliderSize = new UniVector2(1f, 10f),
            Team = Team.Second
        };
    }
}