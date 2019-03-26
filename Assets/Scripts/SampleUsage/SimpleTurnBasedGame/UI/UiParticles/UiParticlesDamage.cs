namespace SimpleTurnBasedGame
{
    public class UiParticlesDamage : UiParticles, IDoDamage
    {
        private IUiPlayer Ui { get; set; }

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            var player = target as IPrimitivePlayer;
            if (player.Seat == Ui.Seat)
                StartCoroutine(Play());
        }

        protected override void Awake()
        {
            base.Awake();
            Ui = GetComponentInParent<IUiPlayer>();
        }
    }
}