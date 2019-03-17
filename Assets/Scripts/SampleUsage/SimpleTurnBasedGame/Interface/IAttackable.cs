namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     All units that are able to attack.
    /// </summary>
    public interface IAttackable
    {
        /// <summary>
        ///     Tries to inflict damage to the target. Returns the effective damage dealt after reductions or bonus.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        int DoAttack(IDamageable target, int amount);
    }
}