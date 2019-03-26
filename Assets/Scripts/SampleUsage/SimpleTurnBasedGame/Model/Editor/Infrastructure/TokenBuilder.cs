using System.Collections.Generic;
using Patterns;

namespace SimpleTurnBasedGame.Infrastructure
{
    public class TokenBuilder : DataBuilder<ProcessTurn>
    {
        private PlayerSeat currentIndex;
        private List<IPrimitivePlayer> defaultPlayers;
        private PlayerSeat startIndex;

        public TokenBuilder(List<IPrimitivePlayer> players)
        {
            defaultPlayers = players;
        }

        public TokenBuilder() : this(new List<IPrimitivePlayer> {(Player) A.Player()})
        {
        }

        public TokenBuilder WithPlayers(List<IPrimitivePlayer> players)
        {
            defaultPlayers = players;
            return this;
        }

        public TokenBuilder WithStartSeat(PlayerSeat start)
        {
            startIndex = start;
            return this;
        }

        public TokenBuilder WithCurrentSeat(PlayerSeat current)
        {
            currentIndex = current;
            return this;
        }

        public override ProcessTurn Build()
        {
            return new ProcessTurn(defaultPlayers, startIndex, currentIndex);
        }
    }
}