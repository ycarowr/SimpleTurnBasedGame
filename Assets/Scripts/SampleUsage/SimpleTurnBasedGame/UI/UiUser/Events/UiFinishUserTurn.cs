using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayerController))]
    public class UiFinishUserTurn : UiListener, IFinishPlayerTurn
    {
        private IUiUserInput UserInput { get; set; }
        private IUiPlayerController Player { get; set; }

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
        {
            if (Player.IsUser)
                UserInput.Disable();
        }

        private void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Player = GetComponent<IUiPlayerController>();
        }
    }
}