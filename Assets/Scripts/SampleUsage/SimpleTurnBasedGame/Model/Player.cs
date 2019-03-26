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
        public Player(PlayerSeat seat, Configurations configurations = null)
        {
            Configurations = configurations;
            Seat = seat;
            DefaultMaxHealth = Configurations.Amount.HealthPlayers.GetHealth(seat);
            Health = DefaultMaxHealth;
        }

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        private int DefaultMaxHealth { get; }
        private Configurations Configurations { get; }
        public PlayerSeat Seat { get; }
        public int Health { get; private set; }
        public bool IsFullHealth => Health == DefaultMaxHealth;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Turn

        void IPrimitivePlayer.FinishTurn()
        {
        }

        void IPrimitivePlayer.StartTurn()
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region DamagePlayers

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

        //----------------------------------------------------------------------------------------------------------

        #region HealPlayers

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

        //----------------------------------------------------------------------------------------------------------
    }
}