namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Start Current PlayerController Turn Implementation.
    /// </summary>
    public class ProcessStartPlayer : ProcessBase
    {
        public ProcessStartPlayer(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Start current player turn logic.
        /// </summary>
        public override void Execute()
        {
            if (Game.IsTurnInProgress)
                return;
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsTurnInProgress = true;
            Game.Token.UpdateCurrentPlayer();
            Game.Token.CurrentPlayer.StartTurn();

            OnStartedCurrentPlayerTurn(Game.Token.CurrentPlayer);
        }

        /// <summary>
        ///     Dispatch start current player turn to the listeners.
        /// </summary>
        /// <param name="currentPlayer"></param>
        private void OnStartedCurrentPlayerTurn(IPrimitivePlayer currentPlayer)
        {
            GameEvents.Instance.Notify<IStartPlayerTurn>(i => i.OnStartPlayerTurn(currentPlayer));
        }
    }
}