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
    } 
}
