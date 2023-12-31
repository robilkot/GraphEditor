﻿using LW5.Interfaces;
using LW5.Logic;

namespace LW5.Commands
{
    public class IsEulerCommand : ICommand
    {
        private Graph _graph;
        public bool Result = false;
        public bool CanBeExecuted => true;
        public IsEulerCommand(Graph graph)
        {
            _graph = graph;
        }
        public void Execute()
        {
            Result = Algorithm.IsEuler(_graph);
        }
    }
}
