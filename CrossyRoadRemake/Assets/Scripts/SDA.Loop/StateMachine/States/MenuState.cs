using UnityEngine.Events;
using SDA.Input;
using SDA.UI;
using SDA.Generation;
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
        private SaveSystem saveSystem;
        private ScoreSystem scoreSystem;
        private AudioSystem audioSystem;

        public MenuState(CrossyInput crossyInput, UnityAction transitionToGameState, MenuView menuView, LaneGenerator laneGenerator, CarStorage carStorage, ScoreSystem scoreSystem, SaveSystem saveSystem, AudioSystem audioSystem)
        {
            this.crossyInput = crossyInput;
            this.transitionToGameState = transitionToGameState;
            this.menuView = menuView;
            this.laneGenerator = laneGenerator;
            this.carStorage = carStorage;
            this.scoreSystem = scoreSystem;
            this.saveSystem = saveSystem;
            this.audioSystem = audioSystem;
        }

        public override void InitState()
        {
            saveSystem.LoadData();
            scoreSystem.InitializeSystem(saveSystem.LoadedData.bestScore);

            menuView.ShowView();
            crossyInput.AddListener(InputType.Any, transitionToGameState.Invoke);           

            carStorage.InitializeStorage();
            laneGenerator.GenerateLevel(carStorage.CarsPool, 40);

            audioSystem.PlayMenuMusic();
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
