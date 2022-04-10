using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class LoseView : BaseView
    {
        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        public Button RestartButton => restartButton;
        public TextMeshProUGUI ScoreText => scoreText;

        public void SetPoints(int points)
        {
            StartCoroutine(CountPoints(points));
        }

        private IEnumerator CountPoints(int points)
        {
            for (int i = 0; i <= points; i++)
            {
                scoreText.text = $"Score: {i}";
                yield return new WaitForSeconds(1f / points);
            }

            var sequence = DOTween.Sequence();
            sequence
                .Append(scoreText.transform.DOScale(1.2f, 0.2f))
                .Append(scoreText.transform.DOScale(1f, 0.2f))
                .SetEase(Ease.Linear);
        }
    } 
}
