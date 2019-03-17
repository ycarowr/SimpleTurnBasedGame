using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiAnimationTurn : UiAnimation, IStartPlayerTurn
    {
        [SerializeField] private PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Animate());
        }
    }
}