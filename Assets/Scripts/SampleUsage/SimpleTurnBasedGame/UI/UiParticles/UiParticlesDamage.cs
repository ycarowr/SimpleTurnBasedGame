namespace SimpleTurnBasedGame
{
    public class UiParticlesDamage : UiParticles, IDoDamage
    {
        public IUiPlayerSeat Player { get; set; }

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
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