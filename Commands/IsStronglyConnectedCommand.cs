using LW5.Interfaces;
using LW5.Logic;

namespace LW5.Commands
{
    public class IsStronglyConnectedCommand : ICommand
    {
        private Graph _graph;
        public bool Result = false;
        public bool CanBeExecuted => true;
        public IsStronglyConnectedCommand(Graph graph)
        {
            _graph = graph;
        }
        public void Execute()
        {
            Result = Algorithm.IsStronglyConnected(_graph);
        }
    }
}
