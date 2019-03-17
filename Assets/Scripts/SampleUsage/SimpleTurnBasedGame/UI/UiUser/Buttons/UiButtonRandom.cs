namespace SimpleTurnBasedGame
{
    public class UiButtonRandom : UiButton
    {
        /// <summary>
        ///     Assign the handler and
        /// </summary>
        /// <param name="handler"></param>
        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressRandom pressRandom)
                AddListener(pressRandom.PressRandomMove);
        }

        /// <summary>
        ///     This interface enforces the button handler to implement the random move.
        /// </summary>
        public interface IPressRandom : IButtonHandler
        {
            void PressRandomMove();
        }
    }
}