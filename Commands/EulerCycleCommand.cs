using LW5.Interfaces;
using LW5.Logic;

namespace LW5.Commands
{
    public class EulerCycleCommand : ICommand
    {
        private Graph _graph;
        public List<Vertex> Result = new();
        public bool CanBeExecuted
        {
            get
            {
                if (Algorithm.IsEuler(_graph) == false)
                {
                    throw new Exception("Граф должен быть эйлеровым");
                }
                return true;
            }
        }
        public EulerCycleCommand(Graph graph)
        {
            _graph = graph;
        }
        public void Execute()
        {
            Result = Algorithm.EulerCycle(_graph);

            if (Result.Count == 0)
            {
                throw new Exception("Граф не содержит эйлеров цикл");
            }
        }
    }
}
