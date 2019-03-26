using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiTextButtonDamage : UiText
    {
        [SerializeField] private Configurations configurations;

        private int MaxDamage => configurations.Amount.Damage.MaxDamage;
        private int MinDamage => configurations.Amount.Damage.MinDamage;

        protected override void Awake()
        {
            base.Awake();
            var damageText = Localization.Instance.Get(LocalizationIds.Damage);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{MinDamage}-{MaxDamage - 1}] {damageText} {moveText}");
        }
    }
}