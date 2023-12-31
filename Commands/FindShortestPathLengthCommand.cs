﻿using LW5.Interfaces;
using LW5.Logic;

namespace LW5.Commands
{
    public class FindShortestPathLengthCommand : ICommand
    {
        private Graph _graph;
        private List<ISelectable> _selection;
        public int Result = 0;
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
        public FindShortestPathLengthCommand(Graph graph, List<ISelectable> selection)
        {
            _graph = graph;
            _selection = selection;
        }
        public void Execute()
        {
            Invoker invoker = new();

            DijkstraCommand dijkstraCommand = new(_graph, _selection);
            invoker.SetCommand(dijkstraCommand);

            invoker.Run();

            PathLengthCommand pathLengthCommand = new(dijkstraCommand.Result);
            invoker.SetCommand(pathLengthCommand);

            invoker.Run();

            Result = pathLengthCommand.Result;
        }
    }
}
