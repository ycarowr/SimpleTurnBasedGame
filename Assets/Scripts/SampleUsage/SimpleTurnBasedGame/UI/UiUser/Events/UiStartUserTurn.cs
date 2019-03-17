using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayerController))]
    public class UiStartUserTurn : UiListener, IStartPlayerTurn
    {
        private const float DelayToEnableInput = 2;
        private IUiUserInput UserInput { get; set; }
        private IUiPlayerController Player { get; set; }

        void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
        {
            if (Player.IsUser && !Player.IsAi)
                StartCoroutine(EnableInput());
        }

        private IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnableInput);
            UserInput.Enable();
        }

        private void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Player = GetComponent<IUiPlayerController>();
        }
    }
}