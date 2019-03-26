using System;
using Patterns.StateMachineMB;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     State Machine that holds all states of a UI Card.
    /// </summary>
    public class UiCardHandSystemMB : StateMachineMB<UiCardHandSystemMB>, IUiCard
    {
        private Transform MyTransform { get; set; }
        private Collider MyCollider { get; set; }
        private SpriteRenderer[] MyRenderers { get; set; }
        private Rigidbody MyRigidbody { get; set; }
        private IMouseInput MyInput { get; set; }
        private IUiCardSelector MyCardSelector { get; set; }

        public UiCardParameters CardConfigsParameters => throw new NotImplementedException();
        SpriteRenderer[] IUiCard.Renderers => MyRenderers;
        Collider IUiCard.Collider => MyCollider;
        Rigidbody IUiCard.Rigidbody => MyRigidbody;
        Transform IUiCard.Transform => MyTransform;
        IMouseInput IUiCard.Input => MyInput;
        IUiCardSelector IUiCard.CardSelector => MyCardSelector;
        public bool IsDragging => IsCurrent<UiCardDragMB>();
        public bool IsHovering => IsCurrent<UiCardHoverMB>();

        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();

            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            MyCardSelector = GetComponentInParent<IUiCardSelector>();
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
        }

        #endregion


        #region Operations

        public void Hover()
        {
            PushState<UiCardHoverMB>();
        }

        public void Disable()
        {
            PushState<UiCardDisableMB>();
        }

        public void Enable()
        {
            PushState<UiCardIdleMB>();
        }

        public void Play()
        {
            MyCardSelector.PlayCard(this);
        }

        public void Select()
        {
            MyCardSelector.SelectCard(this);
            PushState<UiCardDragMB>();
        }

        public void Unselect()
        {
            Enable();
            MyCardSelector.UnselectCard(this);
        }

        #endregion
    }
}