using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiTextButtonRandom : UiText
    {
        [SerializeField] private Configurations configurations;
        private int Bonus => configurations.Amount.Bonus.Value;

        protected override void Awake()
        {
            base.Awake();
            var randomText = Localization.Instance.Get(LocalizationIds.Random);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText(randomText + " " + moveText + " +" + Bonus);
        }
    }
}