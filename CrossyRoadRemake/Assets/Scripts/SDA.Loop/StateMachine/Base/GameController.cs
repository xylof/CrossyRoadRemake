using UnityEngine;
using SDA.Input;
using SDA.UI;
using UnityEngine.Events;
using SDA.Generation;
using SDA.Player;
using SDA.Core;

namespace SDA.Loop
{
    public class GameController : MonoBehaviour
    {
        #region STATES

        private MenuState menuState;
        private GameState gameState;
        private LoseState loseState;

        #endregion

        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private GameView gameView;

        [SerializeField]
        private LoseView loseView;

        private UnityAction transitionToGameState;
        private UnityAction transitionToLoseState;
        private UnityAction transitionToMenuState;

        [SerializeField]
        private CrossyInput crossyInput;

        [SerializeField]
        private LaneGenerator laneGenerator;

        [SerializeField]
        private CarStorage carStorage;

        [SerializeField]
        private PlayerMovement playerMovement;

        [SerializeField]
        private CameraMovement cameraMovement;

        private ScoreSystem scoreSystem;
        private SaveSystem saveSystem;

        [SerializeField]
        private AudioSystem audioSystem;

        private BaseState currentlyActiveState;

        private void Start()
        {
            transitionToGameState = () => ChangeState(gameState);
            transitionToLoseState = () => ChangeState(loseState);
            transitionToMenuState = () => ChangeState(menuState);

            scoreSystem = new ScoreSystem();
            saveSystem = new SaveSystem();

            menuState = new MenuState(crossyInput, transitionToGameState, menuView, laneGenerator, carStorage, scoreSystem, saveSystem, audioSystem);
            gameState = new GameState(gameView, cameraMovement, playerMovement, crossyInput, transitionToLoseState, scoreSystem, audioSystem);
            loseState = new LoseState(crossyInput, loseView, scoreSystem, saveSystem);

            ChangeState(menuState);
        }

        private void Update()
        {
            currentlyActiveState?.UpdateState();
        }

        private void OnDestroy()
        {
            
        }

        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DisposeState();
            currentlyActiveState = newState;
            newState.InitState();
        }

        private void OnApplicationQuit()
        {
            saveSystem.LoadedData.bestScore = scoreSystem.BestScore;
            saveSystem.SaveData();
        }
    } 
}
