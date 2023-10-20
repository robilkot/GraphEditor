using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LW5.Logic;

namespace LW5.UserInterface
{
    public abstract class GraphObjectControl : UserControl, ISelectable, IDeletable
    {
        public GraphControl? GraphControl { get => Parent as GraphControl; }
        public virtual GraphObject Element { get; set; }
        public bool Selected { get; set; }
        protected  bool _mouseHovering = false;
        public virtual void Delete()
        {
            GraphControl?.Remove(this);
            Dispose();
        }
    }
}
