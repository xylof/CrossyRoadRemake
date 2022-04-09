using UnityEngine;

namespace SDA.Core
{
    public class ScoreSystem : MonoBehaviour
    {
        private int points;
        public int GetPoints => points;

        private int steps;

        public void IncrementPoints()
        {
            if (steps == points)
                points++;

            steps++;
        }

        public void DecrementSteps() => steps--;
    } 
}
