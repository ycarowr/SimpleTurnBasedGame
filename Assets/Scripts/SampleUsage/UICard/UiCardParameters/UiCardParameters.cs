using UnityEngine;

namespace Tools.UI.Card
{
    [CreateAssetMenu(menuName = "Card Config Parameters")]
    public class UiCardParameters : ScriptableObject
    {
        #region Disable

        [field: Header("Disable")]
        [field: Tooltip("How a card fades when disabled.")]
        [field: SerializeField]
        [field: Range(0.1f, 1)]
        public float DisabledAlpha { get; set; }

        #endregion

        #region Hover

        [field: Header("Hover")]
        [field: SerializeField]
        [field: Tooltip("How much the card will go upwards when hovered.")]
        [field: Range(0, 2)]
        public float HoverHeight { get; set; }

        [field: SerializeField]
        [field: Tooltip("Whether the hovered card keep its rotation.")]
        public bool HoverRotation { get; set; }

        [field: SerializeField]
        [field: Tooltip("How much a hovered card scales.")]
        [field: Range(0.9f, 2f)]
        public float HoverScale { get; set; }

        #endregion

        #region Bend

        [field: Header("Bend")]
        [field: SerializeField]
        [field: Tooltip("Height factor between two cards.")]
        [field: Range(0f, 1f)]
        public float Height { get; set; }

        [SerializeField] [Tooltip("Amount of space between the cards on the X axis")] [Range(0f, -5f)]
        private float spacing;

        public float Spacing
        {
            get => spacing;
            set => spacing = -value;
        }

        [field: SerializeField]
        [field: Tooltip("Total angle in degrees the cards will bend.")]
        [field: Range(0, 60)]
        public float BentAngle { get; set; }

        #endregion
    }
}