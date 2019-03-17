namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Holds the Game flow when a match is Finished.
    /// </summary>
    public class EndBattleState : BaseBattleState, IFinishGame
    {
        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            Fsm.EndBattle();
        }
    }
}