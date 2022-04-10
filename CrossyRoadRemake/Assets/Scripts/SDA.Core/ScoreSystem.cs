using UnityEngine;
using UnityEngine.Events;

namespace SDA.Core
{
    public class ScoreSystem : MonoBehaviour
    {
        private int points;
        public int GetPoints => points;

        private int steps;

        private int bestScore;
        public int BestScore
        {
            get
            {
                return points < bestScore ? bestScore : points;
            }
        }

        private bool isBestScoreAchieved = false;
        private UnityAction onBestScore;

        public void InitializeSystem(int bestScore)
        {
            this.bestScore = bestScore;
        }

        public void IncrementPoints()
        {
            if (steps == points)
                points++;

            steps++;

            if (points > bestScore && !isBestScoreAchieved) 
            {
                isBestScoreAchieved = true;
                onBestScore.Invoke();
            }
        }

        public void DecrementSteps() => steps--;

        public void onBestScoreAddListener(UnityAction callback)
        {
            onBestScore = callback;
        }
    } 
}
