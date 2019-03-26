using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiUserInput))]
    [RequireComponent(typeof(IUiPlayer))]
    public class UiPreStartGameUser : UiListener, IPreGameStart
    {
        private IUiUserInput UserInput { get; set; }
        private IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            if (Ui.PlayerController.IsMyTurn)
                UserInput.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            UserInput = GetComponent<IUiUserInput>();
            Ui = GetComponentInParent<IUiPlayer>();
        }
    }
}