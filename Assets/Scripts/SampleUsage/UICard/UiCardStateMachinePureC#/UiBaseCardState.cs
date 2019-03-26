using Patterns.StateMachine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     Base UI Card State.
    /// </summary>
    public abstract class UiBaseCardState : IState
    {
        protected const int LayerToRenderNormal = 0;
        protected const int LayerToRenderFirst = 1;

        protected UiBaseCardState(IUiCard handler, UiCardParameters parameters)
        {
            Handler = handler;
            Parameters = parameters;
            IsInitialized = true;
        }

        protected IUiCard Handler { get; }
        protected UiCardParameters Parameters { get; }
        public BaseStateMachine Fsm { get; set; }
        public bool IsInitialized { get; }


        /// <summary>
        ///     Renders the textures in the first layer. Each card state is responsible to handle its own layer activity.
        /// </summary>
        protected virtual void MakeRenderFirst()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                Handler.Renderers[i].sortingOrder = LayerToRenderFirst;
        }


        /// <summary>
        ///     Renders the textures in the regular layer. Each card state is responsible to handle its own layer activity.
        /// </summary>
        protected virtual void MakeRenderNormal()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                Handler.Renderers[i].sortingOrder = LayerToRenderNormal;
        }

        protected void Enable()
        {
            Handler.Collider.enabled = true;
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            NormalColor();
        }

        protected void NormalColor()
        {
            foreach (var renderer in Handler.Renderers)
            {
                var myColor = renderer.color;
                myColor.a = 1;
                renderer.color = myColor;
            }
        }

        #region FSM

        void IState.OnInitialize()
        {
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void OnExitState()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnNextState(IState next)
        {
        }

        public virtual void OnClear()
        {
        }

        #endregion
    }
}