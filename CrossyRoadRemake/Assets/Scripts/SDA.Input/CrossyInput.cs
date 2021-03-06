using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SDA.Input
{
    public enum InputType
    {
        Forward,
        Backward,
        Left,
        Right,
        Any
    }

    public class CrossyInput : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput playerInput;

        private UnityAction moveForwardAction;
        private UnityAction moveBackwardAction;
        private UnityAction moveLeftAction;
        private UnityAction moveRightAction;
        private UnityAction onAnyKey;

        public void AddListener(InputType inputType, UnityAction callback)
        {
            switch (inputType)
            {
                case InputType.Forward:
                    moveForwardAction += callback;
                    break;
                case InputType.Backward:
                    moveBackwardAction += callback;
                    break;
                case InputType.Left:
                    moveLeftAction += callback;
                    break;
                case InputType.Right:
                    moveRightAction += callback;
                    break;
                case InputType.Any:
                    onAnyKey += callback;
                    break;
                default:
                    break;
            }
        }

        public void ClearInputs()
        {
            moveForwardAction = null;
            moveBackwardAction = null;
            moveLeftAction = null;
            moveRightAction = null;
            onAnyKey = null;
        }

        public void OnMoveForward(InputAction.CallbackContext ctx) // Do tej metody trzeba doda? argument typu InputAction.CallbackContext
        {
            if (ctx.action.WasPerformedThisFrame()) // Bez tego ifa jedno wci?ni?cie klawisza spowodowa?oby 3 wywo?ania tego, co jest pod ifem, dzi?ki niemu mamy tylko 1 wywo?anie
            {
                moveForwardAction?.Invoke();
            }
        }

        public void OnMoveBackward(InputAction.CallbackContext ctx) // Do tej metody trzeba doda? argument typu InputAction.CallbackContext
        {
            if (ctx.action.WasPerformedThisFrame()) // Bez tego ifa jedno wci?ni?cie klawisza spowodowa?oby 3 wywo?ania tego, co jest pod ifem, dzi?ki niemu mamy tylko 1 wywo?anie
            {
                moveBackwardAction?.Invoke();
            }
        }

        public void OnMoveLeft(InputAction.CallbackContext ctx) // Do tej metody trzeba doda? argument typu InputAction.CallbackContext
        {
            if (ctx.action.WasPerformedThisFrame()) // Bez tego ifa jedno wci?ni?cie klawisza spowodowa?oby 3 wywo?ania tego, co jest pod ifem, dzi?ki niemu mamy tylko 1 wywo?anie
            {
                moveLeftAction?.Invoke();
            }
        }

        public void OnMoveRight(InputAction.CallbackContext ctx) // Do tej metody trzeba doda? argument typu InputAction.CallbackContext
        {
            if (ctx.action.WasPerformedThisFrame()) // Bez tego ifa jedno wci?ni?cie klawisza spowodowa?oby 3 wywo?ania tego, co jest pod ifem, dzi?ki niemu mamy tylko 1 wywo?anie
            {
                moveRightAction?.Invoke();
            }
        }

        public void OnAnyKeyAction(InputAction.CallbackContext ctx) // Do tej metody trzeba doda? argument typu InputAction.CallbackContext
        {
            if (ctx.action.WasPerformedThisFrame()) // Bez tego ifa jedno wci?ni?cie klawisza spowodowa?oby 3 wywo?ania tego, co jest pod ifem, dzi?ki niemu mamy tylko 1 wywo?anie
            {
                onAnyKey?.Invoke();
            }
        }
    } 
}
