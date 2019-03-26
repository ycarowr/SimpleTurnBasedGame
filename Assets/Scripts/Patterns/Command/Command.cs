namespace Patterns
{
    /// <summary>
    ///     Command base class. 
    ///     Refs: https://java-design-patterns.com/patterns/command/
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}