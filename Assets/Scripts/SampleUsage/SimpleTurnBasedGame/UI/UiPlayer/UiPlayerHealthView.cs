using System.Collections.Generic;

namespace SimpleTurnBasedGame
{
    //TODO: Replace "string.Format(...)" calls by StringBuilder.Append(..)
    public class UiPlayerHealthView : UiListener,
        IPreGameStart,
        IDoDamage,
        IDoHeal
    {
        private IUiPlayerSeat Player { get; set; }
        private IUiPlayerController PlayerController { get; set; }
        private string HealthText { get; set; }
        private UiText UiText { get; set; }

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            UpdateText();
        }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            UpdateText();
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            UpdateText();
        }

        private void Awake()
        {
            UiText = GetComponent<UiText>();
            Player = GetComponentInParent<IUiPlayerSeat>();
            PlayerController = GetComponentInParent<IUiPlayerController>();
            HealthText = Localization.Instance.Get(LocalizationIds.Health);
        }

        private void UpdateText()
        {
            var health = PlayerController.Player.Player.Health;
            UiText.SetText(HealthText + ": " + health);
        }
    }
}