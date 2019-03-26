using System.Collections;
using System.Collections.Generic;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UITextMeshImage
    {
        public UITextMeshImage(TMP_Text text, Image image)
        {
            TmpText = text;
            Image = image;
        }

        public bool Enabled
        {
            get => Image.enabled;
            set
            {
                Image.enabled = value;
                TmpText.enabled = value;
            }
        }

        public TMP_Text TmpText { get; }
        public Image Image { get; }
    }

    public class UiButtonRestart : UiButton,
        IListener,
        IPreGameStart,
        IFinishGame
    {
        private const float DelayToShow = 3.5f;
        private UITextMeshImage UiButton { get; set; }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressRestart restart)
                AddListener(restart.PressRestart);
        }

        private IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(DelayToShow);
            UiButton.Enabled = true;
        }

        public interface IPressRestart
        {
            void PressRestart();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            StartCoroutine(ShowButton());
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            UiButton.Enabled = false;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity callbacks

        protected void Awake()
        {
            UiButton = new UITextMeshImage(
                GetComponentInChildren<TMP_Text>(),
                GetComponent<Image>());
        }

        private void Start()
        {
            GameEvents.Instance.AddListener(this);
        }

        private void OnDestroy()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}