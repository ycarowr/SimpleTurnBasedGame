using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     All UI components that depend of a specific PlayerController.
    /// </summary>
    public interface IUiPlayerSeat
    {
        PlayerSeat Seat { get; }
    }

    public interface IUiPlayerController
    {
        bool IsAi { get; }
        bool IsUser { get; }
        bool IsMyTurn { get; }
        TurnState Player { get; }
    }

    public class UiPlayerContainer : MonoBehaviour, IUiPlayerSeat, IUiPlayerController
    {
        [Tooltip("Position of the UI on the Screen. Assigned by the Editor.")] [SerializeField]
        private PlayerSeat seat;

        #region Properties

        PlayerSeat IUiPlayerSeat.Seat => seat;
        bool IUiPlayerController.IsUser => GameController.Instance.IsUser();
        bool IUiPlayerController.IsMyTurn => GameController.Instance.IsMyTurn(seat);
        bool IUiPlayerController.IsAi => GameController.Instance.GetPlayer(seat).IsAi;
        TurnState IUiPlayerController.Player => GameController.Instance.GetPlayer(seat);

        #endregion
    }
}