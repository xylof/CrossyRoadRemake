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
        private CarStorage carStorage;

        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView, LaneGenerator laneGenerator, CarStorage carStorage)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
            this.carStorage = carStorage;
        }

        public override void InitState()
        {
            menuView.ShowView();
            crossyInput.AddListener(InputType.Any, transitionToGameState.Invoke);           

            carStorage.InitializeStorage();
            laneGenerator.GenerateLevel(carStorage.CarsPool, 20);
        }

        public override void UpdateState()
        {
        }

        public override void DisposeState()
        {
            menuView?.HideView();
            crossyInput.ClearInputs();
        }
    } 
}
