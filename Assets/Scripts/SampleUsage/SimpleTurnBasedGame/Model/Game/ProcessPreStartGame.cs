using System.Collections.Generic;

namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Pre Start Game Step Implementation.
    /// </summary>
    public class ProcessPreStartGame : ProcessBase
    {
        public ProcessPreStartGame(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Execution of start game
        /// </summary>
        public void Execute()
        {
            if (Game.IsGameStarted) return;

            OnGamePreStarted(Game.TurnLogic.Players);
        }

        /// <summary>
        ///     Dispatch pre start game event to the listeners
        /// </summary>
        /// <param name="players"></param>
        private void OnGamePreStarted(List<IPrimitivePlayer> players)
        {
            GameEvents.Instance.Notify<IPreGameStart>(i => i.OnPreGameStart(players));
        }
    }
}