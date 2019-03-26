using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Damage Logic Implementation
    /// </summary>
    public class ProcessHealMove : ProcessBase
    {
        public const int MaxHeal = 4;
        public const int MinHeal = 1;

        public ProcessHealMove(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Execution of the heal logic.
        /// </summary>
        public override void Execute()
        {
            if (!Game.IsTurnInProgress)
                return;

            if (!Game.IsGameStarted)
                return;

            if (Game.IsGameFinished)
                return;

            //get players
            var source = Game.Token.CurrentPlayer as IHealer;
            var target = source as IHealable;

            //do heal
            var healedAmount = source.DoHeal(target, GetHeal());

            //dispatch heal
            OnDoneHeal(source, target, healedAmount);
        }

        /// <summary>
        ///     Generates the heal amount.
        /// </summary>
        /// <returns></returns>
        protected virtual int GetHeal()
        {
            return Random.Range(MinHeal, MaxHeal);
        }

        /// <summary>
        ///     Dispatch heal to the listeners.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        private void OnDoneHeal(IHealer source, IHealable target, int amount)
        {
            GameEvents.Instance.Notify<IDoHeal>(i => i.OnHeal(source, target, amount));
        }
    }
}