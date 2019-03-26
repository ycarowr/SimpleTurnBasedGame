namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Small Part of a Turn.
    /// </summary>
    public abstract class ProcessBase
    {
        protected ProcessBase(IPrimitiveGame game)
        {
            Game = game;
        }

        /// <summary>
        ///     All game data.
        /// </summary>
        protected IPrimitiveGame Game { get; set; }
    }
}