using System;
using Logic;
using Logic.Models;
using UnityEngine;

namespace Services
{
    public class Game
    {
        public Action<Team> OnGoal;
        
        public const int ScoreLimit = 5;
        private readonly Vector3 _cameraPosition = new Vector3(0f, 0f, -10f);
        
        public int FirstPlayerScore { get; private set; }
        public int SecondPlayerScore { get; private set; }
        
        private readonly DependencyContainer _container;
        private BallModel _ball;
        private PlayerModel _firstPlayer;
        private PlayerModel _secondPlayer;

        public Game(DependencyContainer container, Config config)
        {
            _container = container;
            CreateGameWorld(config);
        }
        
        private void CreateGameWorld(Config config)
        {
            _container.UIFactory.CreateGameUISetup(_cameraPosition, this);
            _container.GameFactory.CreateBackground();

            _ball = _container.GameFactory.CreateBall(config.Ball, _container.Math);
            
            _firstPlayer = _container.GameFactory.CreatePlayer(config.FirstPlayer, _container.Math, _ball);
            _secondPlayer = _container.GameFactory.CreatePlayer(config.SecondPlayer, _container.Math, _ball);

            var updateObject = _container.GameFactory.CreateUpdateObject();
            
            _container.GameFactory.CreateWall(config.FirstWall, _ball, updateObject);
            _container.GameFactory.CreateWall(config.SecondWall, _ball, updateObject);

            var firstGate = _container.GameFactory.CreateGate(config.FirstGate, _ball, updateObject);
            firstGate.OnGoal += Goal;

            var secondGate = _container.GameFactory.CreateGate(config.SecondGate, _ball, updateObject);
            secondGate.OnGoal += Goal;
        }

        private void Goal(Team teamLosingPoint)
        {
            IncreaseScore(teamLosingPoint);
            
            var whoScoredGoal = teamLosingPoint == Team.First ? Team.Second : Team.First;
            OnGoal?.Invoke(whoScoredGoal);

            CheckForWinGame();
            ResetGameState();
        }

        private void IncreaseScore(Team teamLosingPoint)
        {
            if (teamLosingPoint == Team.First)
                SecondPlayerScore++;
            if (teamLosingPoint == Team.Second)
                FirstPlayerScore++;
        }

        private void CheckForWinGame()
        {
            if (FirstPlayerScore >= ScoreLimit || SecondPlayerScore >= ScoreLimit)
                _container.SceneLoader.ReloadScene();
        }

        private void ResetGameState()
        {
            _firstPlayer.ResetPosition();
            _secondPlayer.ResetPosition();
            _ball.SetPosition(new UniVector2());
            _ball.SetRandomDirection();
        }
    }
}