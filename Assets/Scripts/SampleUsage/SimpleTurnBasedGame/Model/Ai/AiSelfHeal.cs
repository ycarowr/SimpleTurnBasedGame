namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This AI always heals itself... and never wins.
    /// </summary>
    public class AiSelfHeal : AiBase
    {
        public AiSelfHeal(IPrimitivePlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            return MoveType.HealMove;
        }
    }
}