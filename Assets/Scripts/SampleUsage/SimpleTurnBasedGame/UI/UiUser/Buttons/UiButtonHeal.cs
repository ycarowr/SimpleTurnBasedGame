namespace SimpleTurnBasedGame
{
    public class UiButtonHeal : UiButton
    {
        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressHeal passTurn)
                AddListener(passTurn.PressHealMove);
        }

        public interface IPressHeal : IButtonHandler
        {
            void PressHealMove();
        }
    }
}