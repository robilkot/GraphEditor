namespace LW5.Logic.Commands
{
    public class IsWeaklyConnectedCommand : ICommand
    {
        private Graph _graph;
        public bool Result = false;
        public bool CanBeExecuted => true;
        public IsWeaklyConnectedCommand(Graph graph)
        {
            _graph = graph;
        }
        public void Execute()
        {
            Result = Algorithm.IsWeaklyConnected(_graph);
        }
    }
}
