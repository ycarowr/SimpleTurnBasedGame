using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    //TODO: Consider to split this gigantic interface in smaller ones. SOL(I)D.
    public interface IUiCard : IStateMachineHandler
    {
        UiCardParameters CardConfigsParameters { get; }
        IUiCardSelector CardSelector { get; }
        SpriteRenderer[] Renderers { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        Transform Transform { get; }
        IMouseInput Input { get; }
        GameObject gameObject { get; }
        Transform transform { get; }

        bool IsDragging { get; }
        bool IsHovering { get; }

        //cards operations
        void Play();
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
    }

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardHandSystem : MonoBehaviour, IUiCard
    {
        #region Properties

        private UiCardHandFsm CardHandFsm { get; set; }
        private Transform MyTransform { get; set; }
        private Collider MyCollider { get; set; }
        private SpriteRenderer[] MyRenderers { get; set; }
        private Rigidbody MyRigidbody { get; set; }
        private IMouseInput MyInput { get; set; }
        private IUiCardSelector MyCardSelector { get; set; }
        [field: SerializeField] public UiCardParameters CardConfigsParameters { get; }

        SpriteRenderer[] IUiCard.Renderers => MyRenderers;
        Collider IUiCard.Collider => MyCollider;
        Rigidbody IUiCard.Rigidbody => MyRigidbody;
        Transform IUiCard.Transform => MyTransform;
        IMouseInput IUiCard.Input => MyInput;
        IUiCardSelector IUiCard.CardSelector => MyCardSelector;
        public bool IsDragging => CardHandFsm.IsCurrent<UiCardDrag>();
        public bool IsHovering => CardHandFsm.IsCurrent<UiCardHover>();

        #endregion

        #region Operations

        public void Hover()
        {
            CardHandFsm.Hover();
        }

        public void Disable()
        {
            CardHandFsm.Disable();
        }

        public void Enable()
        {
            CardHandFsm.Enable();
        }

        public void Play()
        {
            MyCardSelector.PlayCard(this);
        }

        public void Select()
        {
            MyCardSelector.SelectCard(this);
            CardHandFsm.Select();
        }

        public void Unselect()
        {
            CardHandFsm.Unselect();
            MyCardSelector.UnselectCard(this);
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            MyCardSelector = GetComponentInParent<IUiCardSelector>();
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
            var camera = Camera.main;
            CardHandFsm = new UiCardHandFsm(camera, CardConfigsParameters, this);
        }

        private void Update()
        {
            CardHandFsm.Update();
        }

        #endregion
    }
}