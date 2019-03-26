namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Start Game Step Implementation.
    /// </summary>
    public class ProcessStartGame : ProcessBase
    {
        public ProcessStartGame(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Execution of start game
        /// </summary>
        public void Execute()
        {
            if (Game.IsGameStarted) return;

            Game.IsGameStarted = true;
            Game.TurnLogic.DecideStarterPlayer();

            OnGameStarted(Game.TurnLogic.StarterPlayer);
        }

        /// <summary>
        ///     Dispatch start game event to the listeners.
        /// </summary>
        /// <param name="starterPlayer"></param>
        private void OnGameStarted(IPrimitivePlayer starterPlayer)
        {
            GameEvents.Instance.Notify<IStartGame>(i => i.OnStartGame(starterPlayer));
        }
    }
}