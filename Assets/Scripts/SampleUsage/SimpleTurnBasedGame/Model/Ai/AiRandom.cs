using UnityEngine;

namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    ///     This AiConfigs module makes random choices.
    /// </summary>
    public class AiRandom : AiBase
    {
        public AiRandom(IPrimitivePlayer player, IPrimitiveGame game) : base(player, game)
        {
        }

        public override MoveType GetBestMove()
        {
            return ChooseRandom(GetAllMoves());
        }

        private MoveType ChooseRandom(MoveType[] availableMoves)
        {
            var rdnIndex = Random.Range(0, availableMoves.Length);
            return availableMoves[rdnIndex];
        }
    }
}