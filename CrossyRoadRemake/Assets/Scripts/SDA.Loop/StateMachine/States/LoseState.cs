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
        private SaveSystem saveSystem;

        public LoseState(CrossyInput crossyInput, LoseView loseView, ScoreSystem scoreSystem, SaveSystem saveSystem)
        {
            this.crossyInput = crossyInput;
            this.loseView = loseView;
            this.scoreSystem = scoreSystem;
            this.saveSystem = saveSystem;
        }

        public override void InitState()
        {
            loseView.ShowView();
            saveSystem.LoadedData.bestScore = scoreSystem.BestScore;
            saveSystem.SaveData();
            loseView.RestartButton.onClick.AddListener(RestartScene);
            loseView.SetPoints(scoreSystem.GetPoints);
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
