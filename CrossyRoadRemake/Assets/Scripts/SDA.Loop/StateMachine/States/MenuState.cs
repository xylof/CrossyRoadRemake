using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SDA.Input;
using SDA.UI;
using SDA.Generation;

namespace SDA.Loop
{
    public class MenuState : BaseState
    {
        private CrossyInput crossyInput;
        private UnityAction transitionToGameState;
        private MenuView menuView;
        private LaneGenerator laneGenerator;

        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView, LaneGenerator laneGenerator)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
        }

        public override void InitState()
        {
            menuView.ShowView();

            crossyInput.AddListener(InputType.Any, transitionToGameState.Invoke);

            crossyInput.AddListener(InputType.Forward, TestFor);
            crossyInput.AddListener(InputType.Backward, TestBac);
            crossyInput.AddListener(InputType.Left, TestLef);
            crossyInput.AddListener(InputType.Right, TestRig);

            laneGenerator.GenerateLevel(20);
        }

        public override void UpdateState()
        {
            Debug.Log("update");
        }

        public override void DisposeState()
        {
            menuView?.HideView();

            crossyInput.ClearInputs();
        }

        public void TestFor()
        {
            Debug.Log("Forward");
        }

        public void TestBac()
        {
            Debug.Log("Backward");
        }

        public void TestLef()
        {
            Debug.Log("Left");
        }

        public void TestRig()
        {
            Debug.Log("Right");
        }
    } 
}