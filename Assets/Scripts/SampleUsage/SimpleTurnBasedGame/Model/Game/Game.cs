using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Simple concrete Game Implementation.
    ///     TODO: Consider to break this class down into small partial classes.
    /// </summary>
    public class Game : IPrimitiveGame
    {
        public Game(List<IPrimitivePlayer> players)
        {
            Token = new TokenTurnLogic(players);
            Log("Game Created");

            //Processes
            ProcessStartGame = new ProcessStartGame(this);
            ProcessStartPlayerTurn = new ProcessStartPlayer(this);
            ProcessFinishPlayerTurn = new ProcessFinishPlayer(this);
            ProcessDamageMove = new ProcessDamageMove(this);
            ProcessHealMove = new ProcessHealMove(this);
            ProcessRandomMove = new ProcessRandomMove(this);
            ProcessTick = new ProcessTick(this);
        }


        private void Log(string log, string colorName = "black")
        {
            log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
            Debug.Log(log);
        }

        #region Properties

        public TokenTurnLogic Token { get; }
        ITokenTurnLogic IPrimitiveGame.Token => Token;
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public bool IsTurnInProgress { get; set; }
        public int TurnTime { get; set; }
        public int TotalTime { get; set; }

        #endregion

        #region Processes

        private ProcessStartGame ProcessStartGame { get; }
        private ProcessTick ProcessTick { get; }
        private ProcessStartPlayer ProcessStartPlayerTurn { get; }
        private ProcessFinishPlayer ProcessFinishPlayerTurn { get; }
        private ProcessDamageMove ProcessDamageMove { get; }
        private ProcessHealMove ProcessHealMove { get; }
        private ProcessRandomMove ProcessRandomMove { get; }

        #endregion

        #region Execution

        public void StartGame()
        {
            ProcessStartGame.Execute();
        }

        public void StartCurrentPlayerTurn()
        {
            ProcessStartPlayerTurn.Execute();
        }

        public void FinishCurrentPlayerTurn()
        {
            ProcessFinishPlayerTurn.Execute();
        }

        public void Heal()
        {
            ProcessHealMove.Execute();
        }

        public void Damage()
        {
            ProcessDamageMove.Execute();
        }

        public void Random()
        {
            ProcessRandomMove.Execute();
        }

        public void Tick()
        {
            ProcessTick.Execute();
        }

        #endregion
    }
}