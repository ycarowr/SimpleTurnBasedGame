namespace Tools.UI.Card
{
    /// <summary>
    ///     This state disables the collider of the card.
    /// </summary>
    public class UiCardDisable : UiBaseCardState
    {
        public UiCardDisable(IUiCard handler, UiCardParameters parameters) : base(handler, parameters)
        {
        }

        public override void OnEnterState()
        {
            Disable();
        }

        /// <summary>
        ///     Disabled state of the card.
        /// </summary>
        private void Disable()
        {
            Handler.Collider.enabled = false;
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            foreach (var renderer in Handler.Renderers)
            {
                var myColor = renderer.color;
                myColor.a = Parameters.DisabledAlpha;
                renderer.color = myColor;
            }
        }
    }
}