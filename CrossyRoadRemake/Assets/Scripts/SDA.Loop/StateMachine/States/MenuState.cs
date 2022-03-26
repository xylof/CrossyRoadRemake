using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SDA.Input;

namespace SDA.Loop
{
    public class MenuState : BaseState
    {
        private CrossyInput crossyInput;

        public MenuState(CrossyInput crossyInput)
        {
            this.crossyInput = crossyInput;
        }

        public override void InitState()
        {
            crossyInput.AddListener(InputType.Forward, TestFor);
            crossyInput.AddListener(InputType.Backward, TestBac);
            crossyInput.AddListener(InputType.Left, TestLef);
            crossyInput.AddListener(InputType.Right, TestRig);
        }

        public override void UpdateState()
        {
            Debug.Log("update");
        }

        public override void DisposeState()
        {
            crossyInput.ClearInputs();
        }

        public void TestFor()
        {
            Debug.Log("For");
        }

        public void TestBac()
        {
            Debug.Log("Back");
        }

        public void TestLef()
        {
            Debug.Log("Lef");
        }

        public void TestRig()
        {
            Debug.Log("Rig");
        }
    } 
}
