using SDA.Core;
using SDA.Input;
using SDA.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SDA.Loop
{
    public class LoseState : BaseState
    {
        private CrossyInput crossyInput;
        private LoseView loseView;
        private ScoreSystem scoreSystem;

        public LoseState(CrossyInput crossyInput, LoseView loseView, ScoreSystem scoreSystem)
        {
            this.crossyInput = crossyInput;
            this.loseView = loseView;
            this.scoreSystem = scoreSystem;
        }

        public override void InitState()
        {
            loseView.ShowView();
            loseView.RestartButton.onClick.AddListener(RestartScene);
            loseView.ScoreText.text = $"Score: {scoreSystem.GetPoints}";
        }

        public override void UpdateState()
        {
        }

        public override void DisposeState()
        {
            loseView?.HideView();
            crossyInput.ClearInputs();
        }

        private void RestartScene()
        {
            SceneManager.LoadScene("Game");
        }
    } 
}
