using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IUiPlayer : IUiController, IUiPlayerController
    {
        PlayerSeat Seat { get; }
    }

    /// <summary>
    ///     Main player UI. It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    public class UiPlayerContainer : MonoBehaviour, IUiPlayer
    {
        public virtual PlayerSeat Seat => PlayerSeat.Top;
        public IGameController GameController => ControllerCs.GameController.Instance;
        public IPlayerTurn PlayerController => ControllerCs.GameController.Instance.GetPlayerController(Seat);
    }
}