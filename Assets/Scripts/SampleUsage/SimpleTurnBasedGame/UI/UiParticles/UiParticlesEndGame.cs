using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiParticlesEndGame : UiParticles, IFinishGame
    {
        private const float DelayToNotify = 1f;
        [SerializeField] private PlayerSeat seat;

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            if (winner.Seat == seat) StartCoroutine(Play(DelayToNotify));
        }
    }
}