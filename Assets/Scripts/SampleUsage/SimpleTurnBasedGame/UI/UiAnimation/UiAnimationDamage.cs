using TMPro;

namespace SimpleTurnBasedGame
{
    public class UiAnimationDamage : UiAnimation, IDoDamage
    {
        private TMP_Text Text { get; set; }

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            Text.text = -amount + " " + Localization.Instance.Get(LocalizationIds.Damage);
            StartCoroutine(Animate());
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}