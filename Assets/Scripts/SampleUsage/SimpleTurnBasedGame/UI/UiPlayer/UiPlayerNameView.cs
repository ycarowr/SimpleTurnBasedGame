using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerNameView : MonoBehaviour
    {
        private string PlayerText { get; set; }
        private UiText UiText { get; set; }
        private IUiPlayer Ui { get; set; }

        private void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UiText = GetComponent<UiText>();
            PlayerText = Localization.Instance.Get(LocalizationIds.Player);
        }

        private void Start()
        {
            UiText.SetText(PlayerText + ": " + Ui.Seat);
        }
    }
}