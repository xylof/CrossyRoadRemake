using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Input;
using UnityEngine.Events;

namespace SDA.Loop
{
    public class GameController : MonoBehaviour
    {
        #region STATES

        private MenuState menuState;

        #endregion

        [SerializeField]
        private CrossyInput crossyInput;

        private BaseState currentlyActiveState;

        private void Start()
        {
            menuState = new MenuState(crossyInput);

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
