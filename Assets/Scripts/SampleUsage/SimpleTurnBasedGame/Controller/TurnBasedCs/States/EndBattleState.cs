namespace SimpleTurnBasedGame.ControllerCs
{
    /// <summary>
    ///     Holds the Game flow when a match is Finished.
    /// </summary>
    public class EndBattleState : BaseBattleState, IFinishGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public EndBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            Fsm.EndBattle();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}