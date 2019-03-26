namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This AiConfigs Module will never try Random Moves.
    /// </summary>
    public class AiUnlucky : AiBase
    {
        public AiUnlucky(IPrimitivePlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            return GetRandomExcept(MoveType.RandomMove);
        }
    }
}