using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SDA.Input;
using SDA.UI;
using SDA.Generation;
using SDA.Player;
using SDA.Core;

namespace SDA.Loop
{
    public class MenuState : BaseState
    {
        private CrossyInput crossyInput;
        private UnityAction transitionToGameState;
        private MenuView menuView;
        private LaneGenerator laneGenerator;
        private CarStorage carStorage;
        private PlayerMovement playerMovement;
        private CameraMovement cameraMovement;

        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView, LaneGenerator laneGenerator, CarStorage carStorage, PlayerMovement playerMovement, CameraMovement cameraMovement)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
            this.carStorage = carStorage;
            this.playerMovement = playerMovement;
            this.cameraMovement = cameraMovement;
        }

        public override void InitState()
        {
            menuView.ShowView();
            //crossyInput.AddListener(InputType.Any, transitionToGameState.Invoke);

            crossyInput.AddListener(InputType.Forward, playerMovement.MoveForward);
            crossyInput.AddListener(InputType.Backward, playerMovement.MoveBackward);
            crossyInput.AddListener(InputType.Left, playerMovement.MoveLeft);
            crossyInput.AddListener(InputType.Right, playerMovement.MoveRight);

            carStorage.InitializeStorage();
            laneGenerator.GenerateLevel(carStorage.CarsPool, 20);
        }

        public override void UpdateState()
        {
            cameraMovement.UpdateCameraPosition();
        }

        public override void DisposeState()
        {
            menuView?.HideView();

            crossyInput.ClearInputs();
        }

        //public void TestFor()
        //{
        //    Debug.Log("Forward");
        //}

        //public void TestBac()
        //{
        //    Debug.Log("Backward");
        //}

        //public void TestLef()
        //{
        //    Debug.Log("Left");
        //}

        //public void TestRig()
        //{
        //    Debug.Log("Right");
        //}
    } 
}
