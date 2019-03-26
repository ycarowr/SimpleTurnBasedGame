namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     TimeOut Logic Implementation
    /// </summary>
    public class ProcessTick : ProcessBase
    {
        public const int TimeOut = 8;
        public const int StartTurnDelay = 1;

        public ProcessTick(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Execution of the tick logic.
        /// </summary>
        public override void Execute()
        {
            if (!Game.IsTurnInProgress)
                return;

            if (!Game.IsGameStarted)
                return;

            if (Game.IsGameFinished)
                return;

            Game.TurnTime++;
            Game.TotalTime++;
            var reverseTime = TimeOut - 1 - Game.TurnTime - StartTurnDelay;
            OnTickTime(reverseTime, Game.Token.CurrentPlayer);
        }

        /// <summary>
        ///     Dispatch tick time to the listeners.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="current"></param>
        private void OnTickTime(int time, IPrimitivePlayer current)
        {
            GameEvents.Instance.Notify<IDoTick>(i => i.OnTickTime(time, current));
        }
    }
}