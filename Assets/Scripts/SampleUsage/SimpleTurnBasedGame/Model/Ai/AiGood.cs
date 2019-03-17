using System.Linq;
using Extensions;

namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This AI module never heals on full life and Kills the enemy is its possible.
    /// </summary>
    public class AiGood : AiBase
    {
        public AiGood(IPrimitivePlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            var canKill = CanKill();
            return canKill ? MoveType.DamageMove : GetCantKillMove();
        }

        private MoveType GetCantKillMove()
        {
            return IsFullHealth() ? MoveType.DamageMove : GetAllMoves().ToList().RandomItem();
        }
    }
}