using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayerController))]
    public class UiUserHudButtons : MonoBehaviour,
        UiButtonRandom.IPressRandom,
        UiButtonDamage.IPressDamage,
        UiButtonHeal.IPressHeal
    {
        private IUiPlayerController PlayerController { get; set; }
        private IUiUserInput UserInput { get; set; }


        void UiButtonDamage.IPressDamage.PressDamageMove()
        {
            var player = PlayerController.Player;
            if (player.ProcessMove(MoveType.DamageMove))
                DisableInput();
        }

        void UiButtonHeal.IPressHeal.PressHealMove()
        {
            var player = PlayerController.Player;
            if (player.ProcessMove(MoveType.HealMove))
                DisableInput();
        }

        void UiButtonRandom.IPressRandom.PressRandomMove()
        {
            var player = PlayerController.Player;
            if (player.ProcessMove(MoveType.RandomMove))
                DisableInput();
        }

        private void Awake()
        {
            PlayerController = GetComponent<IUiPlayerController>();
            UserInput = GetComponent<IUiUserInput>();

            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }

        private void DisableInput()
        {
            UserInput.Disable();
        }
    }
}