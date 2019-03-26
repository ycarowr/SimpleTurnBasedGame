namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This AiConfigs tries to survive if the life total reaches an determined threshold.
    /// </summary>
    public class AiSurvive : AiBase
    {
        private const int HealthThreshold = 3;

        public AiSurvive(IPrimitivePlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        /// <summary>
        ///     If the live total is fewer than the threshold the move is always HealPlayers and survive.
        /// </summary>
        /// <returns></returns>
        public override MoveType GetBestMove()
        {
            return AmIDeadSoon() ? MoveType.HealMove : GetRandomExcept(MoveType.HealMove);
        }


        private bool AmIDeadSoon()
        {
            return Player.Health < HealthThreshold;
        }
    }
}