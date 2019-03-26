namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Finish Current GameController Turn Implementation.
    /// </summary>
    public class ProcessFinishPlayer : ProcessBase
    {
        public ProcessFinishPlayer(IPrimitiveGame game) : base(game)
        {
        }


        /// <summary>
        ///     Finish player turn logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.TurnLogic.CurrentPlayer.FinishTurn();
            Game.TurnTime = 0;
            OnFinishedCurrentPlayerTurn(Game.TurnLogic.CurrentPlayer);
        }

        /// <summary>
        ///     Dispatch to the listeners.
        /// </summary>
        /// <param name="currentPlayer"></param>
        private void OnFinishedCurrentPlayerTurn(IPrimitivePlayer currentPlayer)
        {
            GameEvents.Instance.Notify<IFinishPlayerTurn>(i => i.OnFinishPlayerTurn(currentPlayer));
        }
    }
}