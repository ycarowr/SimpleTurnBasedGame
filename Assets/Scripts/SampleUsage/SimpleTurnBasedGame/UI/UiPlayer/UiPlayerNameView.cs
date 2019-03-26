using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerNameView : MonoBehaviour
    {
        private IUiPlayerSeat Player { get; set; }
        private string PlayerText { get; set; }
        private UiText UiText { get; set; }

        private void Awake()
        {
            UiText = GetComponent<UiText>();
            Player = GetComponentInParent<IUiPlayerSeat>();
            PlayerText = Localization.Instance.Get(LocalizationIds.Player);
        }

        private void Start()
        {
            UiText.SetText(PlayerText + ": " + Player.Seat);
        }
    }
}