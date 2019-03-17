namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Finish Current PlayerController Turn Implementation.
    /// </summary>
    public class ProcessFinishPlayer : ProcessBase
    {
        public ProcessFinishPlayer(IPrimitiveGame game) : base(game)
        {
        }


        /// <summary>
        ///     Finish player turn logic.
        /// </summary>
        public override void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.Token.CurrentPlayer.FinishTurn();
            Game.TurnTime = 0;
            OnFinishedCurrentPlayerTurn(Game.Token.CurrentPlayer);
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