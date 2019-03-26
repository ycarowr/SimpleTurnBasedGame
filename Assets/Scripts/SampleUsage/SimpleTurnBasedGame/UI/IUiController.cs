namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     All child components search for this interface in order
    ///     to resolve dependencies related to the game state.
    /// </summary>
    public interface IUiController
    {
        IGameController GameController { get; }
    }

    public interface IUiPlayerController
    {
        IPlayerTurn PlayerController { get; }
    }
}