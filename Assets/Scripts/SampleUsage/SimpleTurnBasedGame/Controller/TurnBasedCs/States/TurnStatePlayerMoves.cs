using System;

namespace SimpleTurnBasedGame.ControllerCs
{
    public abstract partial class TurnState
    {
        #region Moves
        
        /// <summary>
        ///     Processes a move based on its Type.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool ProcessMove(MoveType move)
        {
            switch (move)
            {
                case MoveType.RandomMove:
                    return TryRandom();
                case MoveType.DamageMove:
                    return TryDamage();
                case MoveType.HealMove:
                    return TryHeal();
                default:
                    throw new ArgumentOutOfRangeException(nameof(move), move, null);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Private
        
        /// <summary>
        ///     Check if the player can pass the turn and passes the turn to the next player.
        /// </summary>
        private bool TryPassTurn()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.FinishCurrentPlayerTurn();
            return true;
        }

        private bool TryRandom()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.Random();
            TryPassTurn();
            return true;
        }

        private bool TryHeal()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.Heal();
            TryPassTurn();
            return true;
        }

        private bool TryDamage()
        {
            if (!IsMyTurn)
                return false;

            GameData.RuntimeGame.Damage();
            TryPassTurn();
            return true;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}