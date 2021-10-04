using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace MudBlazor
{
    public partial class MudContextMenuProvider : MudComponentBase
    {
        [Inject]
        private IContextMenuService _contextMenuService { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private List<ContextMenuReference> _contextMenus { get; set; }  = new List<ContextMenuReference>();

        protected override void OnInitialized()
        {
            ((ContextMenuService)_contextMenuService).OnInstanceAdded += AddInstance;
            ((ContextMenuService)_contextMenuService).OnInstanceCloseRequested += CloseInstance;            

            if(_navigationManager != null)
                _navigationManager.LocationChanged += HandleLocationChanged;
        }

        private void AddInstance(ContextMenuReference contextMenu)
        {
            _contextMenus.Clear();  
            _contextMenus.Add(contextMenu);
            StateHasChanged();
        }

        internal void CloseInstance(Guid id)
        {
            ContextMenuReference contextMenu = _contextMenus.SingleOrDefault(x => x.Id == id);

            if (contextMenu != null)
                CloseInstance(contextMenu);
        }

        private void CloseInstance(ContextMenuReference contextMenu)
        {
            _contextMenus.Remove(contextMenu);
            StateHasChanged();
        }

        public void CloseAll()
        {
            _contextMenus.Clear();
            StateHasChanged();
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs args)
        {
            CloseAll();
        }

        public void Dispose()
        {
            if(_navigationManager != null)
                _navigationManager.LocationChanged -= HandleLocationChanged;
        }
    }
}
