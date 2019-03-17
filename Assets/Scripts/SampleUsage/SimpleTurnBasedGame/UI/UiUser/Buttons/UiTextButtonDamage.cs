namespace SimpleTurnBasedGame
{
    public class UiTextButtonDamage : UiText
    {
        protected override void Awake()
        {
            base.Awake();
            var damageText = Localization.Instance.Get(LocalizationIds.Damage);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{ProcessDamageMove.MinDamage}-{ProcessDamageMove.MaxDamage - 1}] {damageText} {moveText}");
        }
    }
}