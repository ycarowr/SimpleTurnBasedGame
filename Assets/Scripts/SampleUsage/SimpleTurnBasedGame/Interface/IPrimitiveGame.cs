namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Very simple game implementation.
    ///     TODO: Consider to break down this interface in smaller interfaces.
    /// </summary>
    public interface IPrimitiveGame
    {
        ITokenTurnLogic Token { get; }

        bool IsGameStarted { get; set; }

        bool IsGameFinished { get; set; }

        bool IsTurnInProgress { get; set; }

        int TurnTime { get; set; }

        int TotalTime { get; set; }

        void StartGame();

        void StartCurrentPlayerTurn();

        void FinishCurrentPlayerTurn();

        void Heal();

        void Damage();

        void Random();

        void Tick();
    }
}