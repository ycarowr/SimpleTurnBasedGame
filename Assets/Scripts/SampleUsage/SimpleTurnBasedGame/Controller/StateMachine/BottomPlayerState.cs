namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Bottom, where the User is always sitting.
    /// </summary>
    public class BottomPlayerState : AiTurnState
    {
        public override PlayerSeat Seat => PlayerSeat.Bottom;
    }
}