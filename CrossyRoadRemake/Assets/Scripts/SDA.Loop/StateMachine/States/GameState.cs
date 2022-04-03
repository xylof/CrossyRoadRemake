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

        public GameState(GameView gameView, CameraMovement cameraMovement, PlayerMovement playerMovement, CrossyInput crossyInput, UnityAction transitionToLoseState)
        {
            this.gameView = gameView;
            this.cameraMovement = cameraMovement;
            this.playerMovement = playerMovement;
            this.crossyInput = crossyInput;
            this.transitionToLoseState = transitionToLoseState;
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
            playerMovement.OnDieAddListener(transitionToLoseState);
        }

        public override void UpdateState()
        {
            cameraMovement.UpdateCameraPosition();
        }

        public override void DisposeState()
        {
            crossyInput.ClearInputs();
            gameView?.HideView();
        }
    } 
}
