using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MudBlazor
{
    public class ContextMenuReference : IContextMenuReference
    {
        internal Guid Id { get; set; } = Guid.NewGuid();
        internal RenderFragment Content { get; private set; }
        
        public MudContextMenu ContextMenu { get; private set; }

        public ContextMenuReference(Tuple<double,double> xy)
        {
            XY = xy;
        }

        public Tuple<double,double> XY { get; set; }

        internal void InjectContent(RenderFragment renderFragment)
        { 
            Content = renderFragment;
        }

        internal void InjectContextMenu(object inst)
        {
            ContextMenu = inst as MudContextMenu;
        }
    }
}
