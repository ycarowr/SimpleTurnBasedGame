namespace SimpleTurnBasedGame
{
    public interface IUiPlayer
    {
        PlayerSeat Seat { get; }
        bool IsMyTurn();
        TurnState GetPlayer();
    }
}