using System.Collections.Generic;
using Patterns;

namespace SimpleTurnBasedGame
{
    //----------------------------------------------------------------------------------------------------------

    public class GameEvents : Observer<GameEvents>
    {
        protected override void OnAwake()
        {
            Logger.Instance.Log<GameEvents>("Awake");
        }

        private void Start()
        {
            Logger.Instance.Log<GameEvents>("Start");
        }
    }

    //----------------------------------------------------------------------------------------------------------

    #region Game Events Declaration

    /// <summary>
    ///     Broadcast of the players right before the game start.
    /// </summary>
    public interface IPreGameStart : ISubject
    {
        void OnPreGameStart(List<IPrimitivePlayer> players);
    }

    /// <summary>
    ///     Broadcast of the starter player to the Listeners.
    /// </summary>
    public interface IStartGame : ISubject
    {
        void OnStartGame(IPrimitivePlayer starter);
    }

    /// <summary>
    ///     Broadcast of the winner after a game is finished to the Listeners.
    /// </summary>
    public interface IFinishGame : ISubject
    {
        void OnFinishGame(IPrimitivePlayer winner);
    }

    /// <summary>
    ///     Broadcast of a player when it starts the turn to the Listeners.
    /// </summary>
    public interface IStartPlayerTurn : ISubject
    {
        void OnStartPlayerTurn(IPrimitivePlayer player);
    }

    /// <summary>
    ///     Broadcast of a player when it finishes the turn to the Listeners.
    /// </summary>
    public interface IFinishPlayerTurn : ISubject
    {
        void OnFinishPlayerTurn(IPrimitivePlayer player);
    }

    /// <summary>
    ///     Broadcast of a damage to the Listeners.
    /// </summary>
    public interface IDoDamage : ISubject
    {
        void OnDamage(IAttackable source, IDamageable target, int amount);
    }

    /// <summary>
    ///     Broadcast of a heal to the Listeners.
    /// </summary>
    public interface IDoHeal : ISubject
    {
        void OnHeal(IHealer source, IHealable target, int amount);
    }

    /// <summary>
    ///     Broadcast of the time to the Listeners.
    /// </summary>
    public interface IDoTick : ISubject
    {
        void OnTickTime(int time, IPrimitivePlayer player);
    }

    #endregion

    //----------------------------------------------------------------------------------------------------------
}