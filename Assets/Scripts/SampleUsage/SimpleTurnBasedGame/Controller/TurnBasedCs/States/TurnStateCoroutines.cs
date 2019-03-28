using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame.ControllerCs
{
    public abstract partial class TurnState
    {
        #region Coroutines

        private IEnumerator TickRoutineAsync()
        {
            while (true)
            {
                //every second
                yield return new WaitForSeconds(1);
                GameData.RuntimeGame.Tick();
            }
        }

        /// <summary>
        ///     Finishes the player turn.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator TimeOut()
        {
            if (TimeOutRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(TimeOutRoutine);
            else
                yield return new WaitForSeconds(Configurations.TimeOutTurn);

            Moves.TryPassTurn();
        }

        /// <summary>
        ///     Starts the player turn.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator StartTurn()
        {
            yield return new WaitForSeconds(Configurations.TimeStartTurn);
            GameData.RuntimeGame.StartCurrentPlayerTurn();

            //setup tick routine
            TickRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(TickRoutineAsync());
        }

        #endregion
    }
}