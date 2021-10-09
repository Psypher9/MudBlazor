using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace MudBlazor
{
    public partial class MudContextualArea : MudComponentBase
    {

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Action<MouseEventArgs> OnContextMenu { get; set; }
    }
}
