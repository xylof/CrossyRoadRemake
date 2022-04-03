using SDA.Input;
using SDA.UI;

namespace SDA.Loop
{
    public class LoseState : BaseState
    {
        private CrossyInput crossyInput;
        private LoseView loseView;

        public LoseState(CrossyInput crossyInput, LoseView loseView)
        {
            this.crossyInput = crossyInput;
            this.loseView = loseView;
        }

        public override void InitState()
        {
            loseView.ShowView();
        }

        public override void UpdateState()
        {
        }

        public override void DisposeState()
        {
            loseView?.HideView();
            crossyInput.ClearInputs();
        }
    } 
}
