using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class LoseView : BaseView
    {
        [SerializeField]
        private Button restartButton;

        public Button RestartButton => restartButton;
    } 
}
