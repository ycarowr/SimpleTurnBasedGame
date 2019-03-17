namespace SimpleTurnBasedGame
{
    public class UiTextButtonRestart : UiText
    {
        protected override void Awake()
        {
            base.Awake();
            var restartText = Localization.Instance.Get(LocalizationIds.Restart);
            SetText($"{restartText}");
        }
    }
}