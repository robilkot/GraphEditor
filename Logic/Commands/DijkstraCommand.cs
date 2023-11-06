namespace LW5.Logic.Commands
{
    public class DijkstraCommand : ICommand
    {
        private Graph _graph;
        private List<GraphObject> _selection;
        public List<Vertex> Result = new();
        public bool CanBeExecuted
        {
            get
            {
                try
                {
                    return _selection[0] is Vertex && _selection[1] is Vertex;
                }
                catch
                {
                    throw new Exception("Первые два выделенных элемента должны быть вершинами - началом и концом маршрута");
                }
            }
        }
        public DijkstraCommand(Graph graph, List<GraphObject> selection)
        {
            _graph = graph;
            _selection = selection;
        }
        public void Execute()
        {
            Result = Algorithm.Dijkstra(_graph, _selection[0] as Vertex, _selection[1] as Vertex);

            if (Result.Count < 2)
            {
                throw new Exception("Путь между вершинами не существует");
            }
        }
    }
}
