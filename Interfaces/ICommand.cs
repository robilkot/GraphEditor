namespace LW5.Interfaces
{
    public interface ICommand
    {
        public bool CanBeExecuted { get; }
        public void Execute();
    }
}
