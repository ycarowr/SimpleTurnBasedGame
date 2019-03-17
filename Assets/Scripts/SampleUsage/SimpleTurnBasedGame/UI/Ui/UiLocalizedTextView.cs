using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiLocalizedTextView : UiText
    {
        [SerializeField] private LocalizationIds id;

        protected override void Awake()
        {
            base.Awake();
            SetText(Localization.Instance.Get(id));
        }
    }
}