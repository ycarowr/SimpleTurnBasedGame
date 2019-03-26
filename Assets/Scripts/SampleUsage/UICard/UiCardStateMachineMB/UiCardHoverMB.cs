using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    public class UiCardHoverMB : UiBaseCardStateMB
    {
        [SerializeField] [Tooltip("Configurations for Hover State.")]
        private UiCardParameters configParameters;

        private Vector3 StartPosition { get; set; }
        private Quaternion StartRotation { get; set; }
        private Vector3 StartScale { get; set; }

        public override void OnEnterState()
        {
            MakeRenderFirst();

            MyInput.OnPointerExit += OnPointerExit;
            MyInput.OnPointerDown += OnPointerDown;

            //cache old values
            StartPosition = MyTransform.position;
            StartRotation = MyTransform.rotation;
            StartScale = MyTransform.localScale;

            MyTransform.localPosition += new Vector3(0, configParameters.HoverHeight, 0);
            MyTransform.localScale *= configParameters.HoverScale;

            if (!configParameters.HoverRotation)
                MyTransform.localRotation = Quaternion.identity;
        }

        public override void OnExitState()
        {
            MyInput.OnPointerExit -= OnPointerExit;
            MyInput.OnPointerDown -= OnPointerDown;

            //reset position and rotation
            MyTransform.rotation = StartRotation;
            MyTransform.position = StartPosition;
            MyTransform.localScale = StartScale;
        }

        private void OnPointerExit(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Fsm.PushState<UiCardIdleMB>();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Fsm.Select();
        }

        public void OnDestroy()
        {
            MyInput.OnPointerExit -= OnPointerExit;
            MyInput.OnPointerDown -= OnPointerDown;
        }
    }
}