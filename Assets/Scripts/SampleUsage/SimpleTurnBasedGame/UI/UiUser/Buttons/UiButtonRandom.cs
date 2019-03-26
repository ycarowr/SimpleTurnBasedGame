namespace SimpleTurnBasedGame
{
    public class UiButtonRandom : UiButton
    {
        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressRandom pressRandom)
                AddListener(pressRandom.PressRandomMove);
        }

        public interface IPressRandom : IButtonHandler
        {
            void PressRandomMove();
        }
    }
}