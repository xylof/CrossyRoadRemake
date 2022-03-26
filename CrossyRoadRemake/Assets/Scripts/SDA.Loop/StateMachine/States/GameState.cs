using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;

namespace SDA.Loop
{
    public class GameState : BaseState
    {
        private GameView gameView;

        public GameState(GameView gameView)
        {
            this.gameView = gameView;
        }

        public override void InitState()
        {
            gameView.ShowView();

            Debug.Log("game state");
        }

        public override void UpdateState()
        {
        }

        public override void DisposeState()
        {
            gameView?.HideView();
        }
    } 
}
