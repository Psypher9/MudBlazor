using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor
{
    public interface IContextMenuReference
    {
        Tuple<double,double> XY { get; set; }
    }
}
