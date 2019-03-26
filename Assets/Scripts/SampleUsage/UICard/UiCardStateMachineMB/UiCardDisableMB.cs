using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     This state disables the collider of the card.
    /// </summary>
    public class UiCardDisableMB : UiBaseCardStateMB
    {
        [SerializeField] [Tooltip("Configurations for Disabled State.")]
        private UiCardParameters configParameters;

        public override void OnEnterState()
        {
            Disable();
        }

        /// <summary>
        ///     Disabled state of the card.
        /// </summary>
        private void Disable()
        {
            MyCollider.enabled = false;
            MyRigidbody.Sleep();
            MakeRenderNormal();
            foreach (var renderer in MyRenderers)
            {
                var myColor = renderer.color;
                myColor.a = configParameters.DisabledAlpha;
                renderer.color = myColor;
            }
        }
    }
}