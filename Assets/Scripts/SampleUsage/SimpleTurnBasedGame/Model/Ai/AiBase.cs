using System;
using System.Linq;
using Extensions;

namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     Base for all the Artificial Intelligence of the game.
    /// </summary>
    public abstract class AiBase
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected AiBase(IPrimitivePlayer player, IPrimitiveGame game)
        {
            Game = game;
            Player = player;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        protected IPrimitiveGame Game { get; }
        protected IPrimitivePlayer Player { get; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        public abstract MoveType GetBestMove();

        protected MoveType[] GetAllMoves()
        {
            return Enum.GetValues(typeof(MoveType)).Cast<MoveType>().ToArray();
        }

        protected MoveType GetRandomExcept(MoveType move)
        {
            var allMoves = GetAllMoves().ToList();
            allMoves.Remove(move);
            return allMoves.RandomItem();
        }

        protected bool IsFullHealth()
        {
            return Player.IsFullHealth;
        }

        protected bool CanKill()
        {
            var enemy = Game.TurnLogic.GetOpponent(Player);
            return enemy.Health == 1;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}