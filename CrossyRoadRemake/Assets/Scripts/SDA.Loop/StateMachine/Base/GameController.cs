using System.Collections;
using System.Collections.Generic;
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

        #endregion

        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private GameView gameView;

        private UnityAction transitionToGameState;

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

        private BaseState currentlyActiveState;

        private void Start()
        {
            transitionToGameState = () => ChangeState(gameState);

            menuState = new MenuState(crossyInput, transitionToGameState, menuView, laneGenerator, carStorage, playerMovement, cameraMovement);
            gameState = new GameState(gameView);

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
    } 
}
