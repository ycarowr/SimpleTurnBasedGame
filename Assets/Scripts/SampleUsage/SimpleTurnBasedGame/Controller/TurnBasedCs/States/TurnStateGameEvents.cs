namespace SimpleTurnBasedGame.ControllerCs
{
    public abstract partial class TurnState
    {
        #region Game Events

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
        {
            if (IsMyTurn)
                NextTurn();
        }

        /// <summary>
        ///     Switches the turn according to the next player.
        /// </summary>
        private void NextTurn()
        {
            var game = GameData.RuntimeGame;
            var nextPlayer = game.TurnLogic.NextPlayer;
            var nextState = Fsm.GetPlayerController(nextPlayer);
            OnNextState(nextState);
        }

        #endregion
    }
}