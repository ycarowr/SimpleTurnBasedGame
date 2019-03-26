namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This AiConfigs will always try to do damage.
    /// </summary>
    public class AiAggressive : AiBase
    {
        public AiAggressive(IPrimitivePlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            return MoveType.DamageMove;
        }
    }
}