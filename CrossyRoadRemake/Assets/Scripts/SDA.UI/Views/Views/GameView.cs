using TMPro;
using UnityEngine;

namespace SDA.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private TextMeshProUGUI bestScoreText;

        public void UpdateScore(int points, int bestScore)
        {
            scoreText.text = points.ToString();
            bestScoreText.text = bestScore.ToString();
        }
    }
}
