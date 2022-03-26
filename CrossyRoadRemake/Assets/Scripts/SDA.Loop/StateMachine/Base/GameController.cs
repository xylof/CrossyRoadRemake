using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Loop
{
    public class GameController : MonoBehaviour
    {
        #region STATES

        private MenuState menuState;

        #endregion

        private BaseState currentlyActiveState;

        private void Start()
        {
            menuState = new MenuState();

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
