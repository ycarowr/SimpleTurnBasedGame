namespace SimpleTurnBasedGame
{
    public class UiParticlesHeal : UiParticles, IDoHeal
    {
        private IUiPlayer Ui { get; set; }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
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