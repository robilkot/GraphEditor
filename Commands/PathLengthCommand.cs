using LW5.Interfaces;
using LW5.Logic;

namespace LW5.Commands
{
    public class PathLengthCommand : ICommand
    {
        private List<Vertex> _path;
        public int Result = 0;
        public bool CanBeExecuted => true;
        public PathLengthCommand(List<Vertex> path)
        {
            _path = path;
        }
        public void Execute()
        {
            Result = Algorithm.Length(_path);
        }
    }
}
