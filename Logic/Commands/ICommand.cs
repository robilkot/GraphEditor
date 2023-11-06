namespace LW5.Logic.Commands
{
    public interface ICommand
    {
        public bool CanBeExecuted { get; }
        public void Execute();
    }
}
