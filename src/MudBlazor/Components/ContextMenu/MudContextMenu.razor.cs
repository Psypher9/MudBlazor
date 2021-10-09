using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor
{
    public partial class MudContextMenu : MudComponentBase
    {
        protected string Classname =>
                new CssBuilder("mud-context-menu")
                  .AddClass(Class)
                  .Build();

        protected string Stylename =>
             new StyleBuilder()
            .AddStyle("transform", $"translateX(min({X}px, calc(100vw - 100%))) translateY(min({Y}px, calc(100vh - 100%)))")
            .AddStyle(Style)
            .Build();

        [Parameter]
        public RenderFragment Content { get; set; }

        private ElementReference menuContainer { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public double X { get; set; }
        [Parameter]
        public double Y { get; set; }

        [CascadingParameter]
        private MudContextMenuProvider Parent { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await menuContainer.MudFocusFirstAsync();
            }

            await OnAfterRenderAsync(firstRender);
        }

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
