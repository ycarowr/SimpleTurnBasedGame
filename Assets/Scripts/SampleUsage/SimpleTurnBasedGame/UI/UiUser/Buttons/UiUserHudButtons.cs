using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiUserHudButtons : MonoBehaviour,
        UiButtonRandom.IPressRandom,
        UiButtonDamage.IPressDamage,
        UiButtonHeal.IPressHeal
    {
        private IUiPlayer Ui { get; set; }
        private IUiUserInput UserInput { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Unity callback 

        private void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Ui = GetComponent<IUiPlayer>();
            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        private void DisableInput()
        {
            UserInput.Disable();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Buttons

        void UiButtonDamage.IPressDamage.PressDamageMove()
        {
            if (Ui.PlayerController.ProcessMove(MoveType.DamageMove))
                DisableInput();
        }

        void UiButtonHeal.IPressHeal.PressHealMove()
        {
            if (Ui.PlayerController.ProcessMove(MoveType.HealMove))
                DisableInput();
        }

        void UiButtonRandom.IPressRandom.PressRandomMove()
        {
            if (Ui.PlayerController.ProcessMove(MoveType.RandomMove))
                DisableInput();
        }

        #endregion
    }
}