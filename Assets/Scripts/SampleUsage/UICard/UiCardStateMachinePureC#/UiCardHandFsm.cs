using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     State Machine that holds all states of a UI Card.
    /// </summary>
    public class UiCardHandFsm : BaseStateMachine
    {
        public UiCardHandFsm(Camera camera, UiCardParameters cardConfigsParameters, IUiCard handler = null) :
            base(handler)
        {
            CardConfigsParameters = cardConfigsParameters;

            IdleState = new UiCardIdle(handler, CardConfigsParameters);
            DisableState = new UiCardDisable(handler, CardConfigsParameters);
            DragState = new UiCardDrag(handler, camera, CardConfigsParameters);
            HoverState = new UiCardHover(handler, CardConfigsParameters);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(DragState);
            RegisterState(HoverState);

            Initialize();
        }

        private UiCardParameters CardConfigsParameters { get; }

        //states
        private UiCardIdle IdleState { get; }
        private UiCardDisable DisableState { get; }
        private UiCardDrag DragState { get; }
        private UiCardHover HoverState { get; }

        public void Hover()
        {
            PushState<UiCardHover>();
        }

        public void Disable()
        {
            PushState<UiCardDisable>();
        }

        public void Enable()
        {
            PushState<UiCardIdle>();
        }

        public void Select()
        {
            PushState<UiCardDrag>();
        }

        public void Unselect()
        {
            Enable();
        }
    }
}