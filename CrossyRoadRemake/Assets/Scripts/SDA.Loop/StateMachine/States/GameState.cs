using SDA.UI;
using SDA.Core;
using SDA.Player;
using SDA.Input;
using UnityEngine.Events;

namespace SDA.Loop
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private CameraMovement cameraMovement;
        private PlayerMovement playerMovement;
        private CrossyInput crossyInput;
        private UnityAction transitionToLoseState;
        private ScoreSystem scoreSystem;
        private AudioSystem audioSystem;

        public GameState(GameView gameView, CameraMovement cameraMovement, PlayerMovement playerMovement, CrossyInput crossyInput, UnityAction transitionToLoseState, ScoreSystem scoreSystem, AudioSystem audioSystem)
        {
            this.gameView = gameView;
            this.cameraMovement = cameraMovement;
            this.playerMovement = playerMovement;
            this.crossyInput = crossyInput;
            this.transitionToLoseState = transitionToLoseState;
            this.scoreSystem = scoreSystem;
            this.audioSystem = audioSystem;
        }

        public override void InitState()
        {
            gameView.ShowView();

            crossyInput.AddListener(InputType.Forward, playerMovement.MoveForward);
            crossyInput.AddListener(InputType.Backward, playerMovement.MoveBackward);
            crossyInput.AddListener(InputType.Left, playerMovement.MoveLeft);
            crossyInput.AddListener(InputType.Right, playerMovement.MoveRight);
            playerMovement.InitPlayer();
            playerMovement.MoveForward();

            UnityAction onDieAction = transitionToLoseState;
            onDieAction += audioSystem.PlayDeathMusic;

            playerMovement.OnJumpAddListener(audioSystem.PlayJumpMusic);
            scoreSystem.onBestScoreAddListener(audioSystem.PlayBestScoreMusic);

            playerMovement.OnDieAddListener(onDieAction);
            playerMovement.OnOneStepForwardAddListener(scoreSystem.IncrementPoints);
            playerMovement.OnOneStepBackwardAddListener(scoreSystem.DecrementSteps);

            audioSystem.PlayGameMusic();
        }

        public override void UpdateState()
        {
            cameraMovement.UpdateCameraPosition();
            gameView.UpdateScore(scoreSystem.GetPoints, scoreSystem.BestScore);
        }

        public override void DisposeState()
        {
            crossyInput.ClearInputs();
            gameView?.HideView();
        }
    } 
}
