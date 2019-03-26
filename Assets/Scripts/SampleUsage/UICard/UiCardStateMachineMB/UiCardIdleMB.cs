using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    /// <summary>
    ///     UI Card Idle behavior.
    /// </summary>
    public class UiCardIdleMB : UiBaseCardStateMB
    {
        public override void OnAwake()
        {
            base.OnAwake();
            MyInput.OnPointerDown += OnPointerDown;
            MyInput.OnPointerEnter += OnPointerEnter;
        }

        public override void OnEnterState()
        {
            Enable();
            MakeRenderNormal();
        }

        private void OnPointerEnter(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Fsm.Hover();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Fsm.Select();
        }

        private void OnDestroy()
        {
            MyInput.OnPointerDown -= OnPointerDown;
        }
    }
}