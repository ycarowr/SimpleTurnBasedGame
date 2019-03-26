using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class ProcessRandomMove : ProcessBase
    {
        private const int BonusByPlayingRandom = 2;

        public ProcessRandomMove(IPrimitiveGame game) : base(game)
        {
            DamagePlus = new ProcessDamagePlus(game);
            HealPlus = new ProcessHealPlus(game);
        }

        private ProcessDamagePlus DamagePlus { get; }
        private ProcessHealPlus HealPlus { get; }

        public override void Execute()
        {
            var rdn = Random.Range(0, 2);

            //Heads or Tails?
            if (rdn == 0)
                DamagePlus.Execute();
            else
                HealPlus.Execute();
        }

        #region Decorators

        private class ProcessDamagePlus : ProcessDamageMove
        {
            public ProcessDamagePlus(IPrimitiveGame game) : base(game)
            {
            }

            protected override int GetDamage()
            {
                return base.GetDamage() + BonusByPlayingRandom;
            }
        }

        private class ProcessHealPlus : ProcessHealMove
        {
            public ProcessHealPlus(IPrimitiveGame game) : base(game)
            {
            }

            protected override int GetHeal()
            {
                return base.GetHeal() + BonusByPlayingRandom;
            }
        }

        #endregion
    }
}