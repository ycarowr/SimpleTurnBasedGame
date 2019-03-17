using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiParticlesTurn : UiParticles, IStartPlayerTurn
    {
        [SerializeField] private PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Play());
        }
    }
}