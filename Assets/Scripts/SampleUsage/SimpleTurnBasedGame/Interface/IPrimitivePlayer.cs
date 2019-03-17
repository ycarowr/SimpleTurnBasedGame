namespace SimpleTurnBasedGame
{
    public interface IPrimitivePlayer
    {
        PlayerSeat Seat { get; }
        int Health { get; }
        bool IsFullHealth { get; }

        void StartTurn();
        void FinishTurn();
    }
}