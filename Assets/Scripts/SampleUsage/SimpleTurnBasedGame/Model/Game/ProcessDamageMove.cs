using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     DamagePlayers Logic Implementation
    /// </summary>
    public class ProcessDamageMove : ProcessBase
    {
        public ProcessDamageMove(IPrimitiveGame game) : base(game)
        {
            ProcessFinishGameStep = new ProcessFinishGame(game);
        }

        private int MaxDamage => Game.Configurations.Amount.Damage.MaxDamage;
        private int MinDamage => Game.Configurations.Amount.Damage.MinDamage;
        private ProcessFinishGame ProcessFinishGameStep { get; }

        /// <summary>
        ///     Execution of the damage logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress)
                return;

            if (!Game.IsGameStarted)
                return;

            if (Game.IsGameFinished)
                return;

            //get players
            var source = Game.TurnLogic.CurrentPlayer as IAttackable;
            var target = Game.TurnLogic.GetOpponent(source as IPrimitivePlayer) as IDamageable;

            //do attack
            var damageDealt = source.DoAttack(target, GetDamage());

            //dispatch damage
            OnDoneDamage(source, target, damageDealt);

            //check health
            if (IsTargetDead(target))
                ProcessFinishGameStep.Execute(source as IPrimitivePlayer);
        }

        private bool IsTargetDead(IDamageable target)
        {
            return (target as Player).Health == 0;
        }

        /// <summary>
        ///     Generates the damage amount.
        /// </summary>
        /// <returns></returns>
        protected virtual int GetDamage()
        {
            return Random.Range(MinDamage, MaxDamage);
        }

        /// <summary>
        ///     Dispatch damage dealt to the listeners.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        private void OnDoneDamage(IAttackable source, IDamageable target, int amount)
        {
            GameEvents.Instance.Notify<IDoDamage>(i => i.OnDamage(source, target, amount));
        }
    }
}