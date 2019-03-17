namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     All units that are able to heal.
    /// </summary>
    public interface IHealer
    {
        /// <summary>
        ///     Tries to heal the target. Returns the effective heal amount after possible reductions or bonus.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="healAmount"></param>
        /// <returns></returns>
        int DoHeal(IHealable target, int healAmount);
    }
}