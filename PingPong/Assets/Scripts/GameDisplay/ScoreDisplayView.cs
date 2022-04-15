using Services;
using TMPro;
using UnityEngine;

namespace GameDisplay
{
    public class ScoreDisplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _firstPlayerScoreTMP;
        [SerializeField] private TextMeshProUGUI _secondPlayerScoreTMP;

        public void IncreaseFirstPlayerScore(Game game) => 
            _firstPlayerScoreTMP.text = $"{game.FirstPlayerScore}";
        
        public void IncreaseSecondPlayerScore(Game game) => 
            _secondPlayerScoreTMP.text = $"{game.SecondPlayerScore}";
    }
}