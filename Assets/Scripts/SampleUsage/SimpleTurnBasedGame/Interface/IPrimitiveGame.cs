namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Very simple game implementation.
    ///     TODO: Consider to break down this interface in smaller interfaces.
    /// </summary>
    public interface IPrimitiveGame
    {
        Configurations Configurations { get; }

        ITurnLogic TurnLogic { get; }

        bool IsGameStarted { get; set; }

        bool IsGameFinished { get; set; }

        bool IsTurnInProgress { get; set; }

        int TurnTime { get; set; }

        int TotalTime { get; set; }

        void PreStartGame();

        void StartGame();

        void StartCurrentPlayerTurn();

        void FinishCurrentPlayerTurn();

        void Heal();

        void Damage();

        void Random();

        void Tick();
    }
}