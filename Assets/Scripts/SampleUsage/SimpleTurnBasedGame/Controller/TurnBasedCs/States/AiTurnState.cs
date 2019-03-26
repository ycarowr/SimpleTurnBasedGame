using System.Collections;
using SimpleTurnBasedGame.AI;
using UnityEngine;

namespace SimpleTurnBasedGame.ControllerCs
{
    public class AiTurnState : TurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected AiTurnState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
            AiModule = new AiModule(Player, GameData.RuntimeGame);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        private Coroutine AiFinishTurnRoutine { get; set; }
        private AiModule AiModule { get; }
        protected virtual AiArchetype AiArchetype => Configurations.Ai.TopPlayer.Archetype;
        private float AiFinishTurnDelay => Configurations.AiFinishTurnDelay;
        private float AiDoTurnDelay => Configurations.AiDoTurnDelay;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        protected override IEnumerator StartTurn()
        {
            AiModule.SwapAiToArchetype(AiArchetype);
            yield return base.StartTurn();
            //call do turn routine
            Fsm.Handler.MonoBehaviour.StartCoroutine(AiDoTurn());
            //call finish turn routine
            AiFinishTurnRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(AiFinishTurn(AiFinishTurnDelay));
        }

        protected override void RestartTimeouts()
        {
            base.RestartTimeouts();

            if (AiFinishTurnRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(AiFinishTurnRoutine);
            AiFinishTurnRoutine = null;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Coroutines

        private IEnumerator AiDoTurn()
        {
            yield return new WaitForSeconds(AiDoTurnDelay);

            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            var bestMove = AiModule.GetBestMove();
            ProcessMove(bestMove);
        }

        private IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            Fsm.Handler.MonoBehaviour.StartCoroutine(TimeOut());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}