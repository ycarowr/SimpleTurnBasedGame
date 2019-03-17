namespace SimpleTurnBasedGame
{
    public class UiParticlesStartGame : UiParticles, IStartGame
    {
        private const float DelayToNotify = 0.75f;

        void IStartGame.OnStartGame(IPrimitivePlayer player)
        {
            StartCoroutine(Play(DelayToNotify));
        }
    }
}