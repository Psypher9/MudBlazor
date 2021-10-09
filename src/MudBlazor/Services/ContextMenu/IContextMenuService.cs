using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor
{
    public interface IContextMenuService
    {
        IContextMenuReference Open<T>(double x, double y) where T : ComponentBase, new();
        IContextMenuReference Open<T>(double x, double y, Action<T> builder) where T : ComponentBase, new();

        void Close(Guid id);
    }
}
