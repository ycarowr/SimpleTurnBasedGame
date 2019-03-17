namespace SimpleTurnBasedGame
{
    public class UiButtonDamage : UiButton
    {
        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressDamage passTurn)
                AddListener(passTurn.PressDamageMove);
        }

        public interface IPressDamage : IButtonHandler
        {
            void PressDamageMove();
        }
    }
}