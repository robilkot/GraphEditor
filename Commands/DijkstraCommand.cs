using LW5.Interfaces;
using LW5.Logic;
using LW5.UserInterface;

namespace LW5.Commands
{
    public class DijkstraCommand : ICommand
    {
        private Graph _graph;
        private List<ISelectable> _selection;
        public List<Vertex> Result = new();
        public bool CanBeExecuted
        {
            get
            {
                try
                {
                    return ((VertexControl)_selection[0]).Element is Vertex && ((VertexControl)_selection[1]).Element is Vertex;
                }
                catch
                {
                    throw new Exception("Первые два выделенных элемента должны быть вершинами - началом и концом маршрута");
                }
            }
        }
        public DijkstraCommand(Graph graph, List<ISelectable> selection)
        {
            _graph = graph;
            _selection = selection;
        }
        public void Execute()
        {
            Result = Algorithm.Dijkstra(_graph, ((VertexControl)_selection[0]).Element as Vertex, ((VertexControl)_selection[1]).Element as Vertex);

            if (Result.Count < 2)
            {
                throw new Exception("Путь между вершинами не существует");
            }
        }
    }
}
