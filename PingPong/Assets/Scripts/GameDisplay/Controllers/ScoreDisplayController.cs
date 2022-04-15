using Logic;
using Services;

namespace GameDisplay.Controllers
{
    public class ScoreDisplayController
    {
        private readonly ScoreDisplayView _scoreDisplayView;
        private readonly Game _game;

        public ScoreDisplayController(ScoreDisplayView scoreDisplayView, Game game)
        {
            _scoreDisplayView = scoreDisplayView;
            _game = game;
            
            _game.OnGoal += Goal;
        }

        private void Goal(Team whoScoredGoal)
        {
            if (whoScoredGoal == Team.First)
                _scoreDisplayView.IncreaseFirstPlayerScore(_game);
            if (whoScoredGoal == Team.Second)
                _scoreDisplayView.IncreaseSecondPlayerScore(_game);
        }
    }
}