using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IRestartGameHandler
    {
        void RestartGame();
    }

    /// <summary>
    ///     End game HUD. Solves model dependencies accessing the game controller via Singleton.
    /// </summary>
    [RequireComponent(typeof(IUiUserInput))]
    public class UiEndGameContainer : UiListener,
        IRestartGameHandler,
        IFinishGame,
        IStartGame,
        IUiController
    {
        //----------------------------------------------------------------------------------------------------------

        void IRestartGameHandler.RestartGame()
        {
            GameController.RestartGameImmediately();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        private void Awake()
        {
            //user input
            UserInput = gameObject.AddComponent<UiUserInput>();

            //HUD end game
            gameObject.AddComponent<UiButtonsEndGame>();
        }

        #endregion

        private IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnable);
            UserInput.Enable();
        }
        //----------------------------------------------------------------------------------------------------------

        #region Properties

        private const float DelayToEnable = 1f;
        private IUiUserInput UserInput { get; set; }
        public IGameController GameController => ControllerCs.GameController.Instance;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            StartCoroutine(EnableInput());
        }

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            UserInput.Disable();
        }

        #endregion
    }
}