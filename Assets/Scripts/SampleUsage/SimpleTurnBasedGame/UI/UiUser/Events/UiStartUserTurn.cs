using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiStartUserTurn : UiListener, IStartPlayerTurn
    {
        private const float DelayToEnableInput = 2;
        private IUiUserInput UserInput { get; set; }
        private IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
        {
            var isMyTurn = Ui.PlayerController.IsMyTurn;
            var isUser = Ui.PlayerController.IsUser;
            var notAi = !Ui.PlayerController.IsAi;

            if (isMyTurn && isUser && notAi)
                StartCoroutine(EnableInput());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        private IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnableInput);
            UserInput.Enable();
        }

        private void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UserInput = GetComponent<IUiUserInput>();
        }
    }
}