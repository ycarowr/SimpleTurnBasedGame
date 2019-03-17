namespace SimpleTurnBasedGame
{
    public class UiParticlesHeal : UiParticles, IDoHeal
    {
        public IUiPlayerSeat Player { get; set; }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            var player = target as IPrimitivePlayer;
            if (player.Seat == Player.Seat)
                StartCoroutine(Play());
        }

        protected override void Awake()
        {
            base.Awake();
            Player = GetComponentInParent<IUiPlayerSeat>();
        }
    }
}