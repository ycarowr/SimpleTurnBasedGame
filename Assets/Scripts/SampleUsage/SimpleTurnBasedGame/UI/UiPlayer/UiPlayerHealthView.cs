using System.Collections.Generic;

namespace SimpleTurnBasedGame
{
    public class UiPlayerHealthView : UiListener,
        IPreGameStart,
        IDoDamage,
        IDoHeal
    {
        private string HealthText { get; set; }
        private UiText UiText { get; set; }
        private IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UiText = GetComponent<UiText>();
            HealthText = Localization.Instance.Get(LocalizationIds.Health);
        }

        private void SetHealth()
        {
            var health = Ui.PlayerController.Player.Health;
            UiText.SetText(HealthText + ": " + health);
        }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events 

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            SetHealth();
        }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            SetHealth();
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            SetHealth();
        }

        #endregion
    }
}