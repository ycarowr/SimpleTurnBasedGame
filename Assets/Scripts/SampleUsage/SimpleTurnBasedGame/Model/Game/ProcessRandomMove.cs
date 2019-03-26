using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class ProcessRandomMove : ProcessBase
    {
        public ProcessRandomMove(IPrimitiveGame game) : base(game)
        {
            Bonus = Game.Configurations.Amount.Bonus.Value;

            DamagePlus = new ProcessDamagePlus(game, Bonus);
            HealPlus = new ProcessHealPlus(game, Bonus);
        }

        public int Bonus { get; }
        private ProcessDamagePlus DamagePlus { get; }
        private ProcessHealPlus HealPlus { get; }

        public void Execute()
        {
            var rdn = Random.Range(0, 2);

            //Heads or Tails?
            if (rdn == 0)
                DamagePlus.Execute();
            else
                HealPlus.Execute();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Decorators

        private class ProcessDamagePlus : ProcessDamageMove
        {
            public ProcessDamagePlus(IPrimitiveGame game, int bonus) : base(game)
            {
                Bonus = bonus;
            }

            private int Bonus { get; }

            protected override int GetDamage()
            {
                return base.GetDamage() + Bonus;
            }
        }

        private class ProcessHealPlus : ProcessHealMove
        {
            public ProcessHealPlus(IPrimitiveGame game, int bonus) : base(game)
            {
            }

            private int Bonus { get; }

            protected override int GetHeal()
            {
                return base.GetHeal() + Bonus;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}