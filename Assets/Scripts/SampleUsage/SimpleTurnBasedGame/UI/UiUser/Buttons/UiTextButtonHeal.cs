namespace SimpleTurnBasedGame
{
    public class UiTextButtonHeal : UiText
    {
        protected override void Awake()
        {
            base.Awake();
            var healText = Localization.Instance.Get(LocalizationIds.Heal);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{ProcessHealMove.MinHeal}-{ProcessHealMove.MaxHeal - 1}] {healText} {moveText}");
        }
    }
}