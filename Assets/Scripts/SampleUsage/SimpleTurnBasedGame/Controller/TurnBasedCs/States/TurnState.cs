using System;
using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame.ControllerCs
{
    public abstract class TurnState : BaseBattleState, IFinishPlayerTurn, IPlayerTurn
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected TurnState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
            var game = GameData.RuntimeGame;

            //get player according to the seat
            Player = game.TurnLogic.GetPlayer(Seat);

            //register turn state
            Fsm.RegisterPlayerState(Player, this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public IPrimitivePlayer Player { get; }
        public IPrimitivePlayer Opponent => GameData.RuntimeGame.TurnLogic.GetOpponent(Player);
        public bool IsMyTurn => GameData.RuntimeGame.TurnLogic.IsMyTurn(Player);
        public virtual PlayerSeat Seat => PlayerSeat.Top;
        public virtual bool IsAi => false;
        public virtual bool IsUser => false;

        private Coroutine TimeOutRoutine { get; set; }
        private Coroutine TickRoutine { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
        {
            if (IsMyTurn)
                NextTurn();
        }

        /// <summary>
        ///     Switches the turn according to the next player.
        /// </summary>
        private void NextTurn()
        {
            var game = GameData.RuntimeGame;
            var nextPlayer = game.TurnLogic.NextPlayer;
            var nextState = Fsm.GetPlayerController(nextPlayer);
            OnNextState(nextState);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnEnterState()
        {
            base.OnEnterState();

            //setup timer to end the turn
            TimeOutRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(TimeOut());

            //start current player turn
            Fsm.Handler.MonoBehaviour.StartCoroutine(StartTurn());
        }

        public override void OnExitState()
        {
            base.OnExitState();
            RestartTimeouts();
        }

        /// <summary>
        ///     Clear the state to the initial configuration and stops all the internal routines.
        /// </summary>
        public override void OnClear()
        {
            base.OnClear();
            RestartTimeouts();
        }

        protected virtual void RestartTimeouts()
        {
            if (TimeOutRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(TimeOutRoutine);
            TimeOutRoutine = null;

            if (TickRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(TickRoutine);
            TickRoutine = null;
        }

        #region Player Moves

        /// <summary>
        ///     Processes a move based on its Type.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool ProcessMove(MoveType move)
        {
            switch (move)
            {
                case MoveType.RandomMove:
                    return TryRandom();
                case MoveType.DamageMove:
                    return TryDamage();
                case MoveType.HealMove:
                    return TryHeal();
                default:
                    throw new ArgumentOutOfRangeException(nameof(move), move, null);
            }
        }

        /// <summary>
        ///     Check if the player can pass the turn and passes the turn to the next player.
        /// </summary>
        protected bool TryPassTurn()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.FinishCurrentPlayerTurn();
            return true;
        }

        protected bool TryRandom()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.Random();
            TryPassTurn();
            return true;
        }

        protected bool TryHeal()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.Heal();
            TryPassTurn();
            return true;
        }

        protected bool TryDamage()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.Damage();
            TryPassTurn();
            return true;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #endregion

        //----------------------------------------------------------------------------------------------------------

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

            TryPassTurn();
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

        //----------------------------------------------------------------------------------------------------------
    }
}