namespace SimpleTurnBasedGame
{
    public class UiTextButtonRandom : UiText
    {
        protected override void Awake()
        {
            base.Awake();
            var randomText = Localization.Instance.Get(LocalizationIds.Random);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText(randomText + " " + moveText + " +2");
        }
    }
}