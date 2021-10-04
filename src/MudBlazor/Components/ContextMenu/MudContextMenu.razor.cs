using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor
{
    public partial class MudContextMenu : MudComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public double X { get; set; }
        [Parameter]
        public double Y { get; set; }

        [CascadingParameter]
        private MudContextMenuProvider Parent { get; set; }

        public void SetCoordinates(Tuple<double, double> xy)
        {
            X = xy.Item1;
            Y = xy.Item2;
        }

        public void Close()
        {
            Parent.CloseAll();
        }
    }
}
