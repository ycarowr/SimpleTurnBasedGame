using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Simple concrete player class.
    /// </summary>
    public class Player : IPrimitivePlayer,
        IDamageable, IAttackable,
        IHealable, IHealer
    {
        private const int DefaultMaxHealth = 6;

        public Player(PlayerSeat seat)
        {
            Seat = seat;
            Health = DefaultMaxHealth;
        }

        public PlayerSeat Seat { get; }
        public int Health { get; private set; }
        public bool IsFullHealth => Health == DefaultMaxHealth;

        #region Turn

        void IPrimitivePlayer.FinishTurn()
        {
        }

        void IPrimitivePlayer.StartTurn()
        {
        }

        #endregion

        #region Damage

        int IAttackable.DoAttack(IDamageable target, int bonusDamage)
        {
            return target.TakeDamage(this, bonusDamage);
        }

        int IDamageable.TakeDamage(IAttackable source, int amount)
        {
            return IgnoreOverKill(amount);
        }

        private int IgnoreOverKill(int damage)
        {
            var current = Health;
            var total = Health - damage;
            Health = Mathf.Max(total, 0);
            return Health - current;
        }

        #endregion

        #region Heal

        int IHealer.DoHeal(IHealable target, int healAmount)
        {
            return target.TakeHeal(this, healAmount);
        }

        int IHealable.TakeHeal(IHealer source, int amount)
        {
            return IgnoreOverHeal(amount);
        }

        private int IgnoreOverHeal(int heal)
        {
            var current = Health;
            var total = Health + heal;
            Health = Mathf.Min(total, DefaultMaxHealth);
            return Health - current;
        }

        #endregion
    }
}