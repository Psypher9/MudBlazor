using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MudBlazor
{
    public class ContextMenuService : IContextMenuService
    {
        internal event Action<ContextMenuReference> OnInstanceAdded;
        internal event Action<Guid> OnInstanceCloseRequested;

        public IContextMenuReference Open<T>(double x, double y) where T : ComponentBase, new()
        {
            return Open<T>(x, y, builder => { });
        }

        public IContextMenuReference Open<T>(double x, double y, Action<T> builder) where T : ComponentBase, new()
        {
            T instance = new T();
            builder(instance);

            return Open(x, y, instance);
        }
        
        private IContextMenuReference Open<T>(double x, double y, T contentComponent) where T : ComponentBase, new()
        {
            ContextMenuReference contextMenuRef = new ContextMenuReference(new(x, y));
            Type componentType = contentComponent.GetType();

            var contextMenuContent = new RenderFragment(builder => {
                int i = 0;
                builder.OpenComponent(i++, componentType);
                foreach(var param in componentType.GetProperties())
                {
                    builder.AddAttribute(i++, param.Name, param.GetValue(contentComponent));
                }                
                builder.AddComponentReferenceCapture(i, inst => contextMenuRef.InjectContextMenu(inst));
                builder.CloseComponent();
            });

            var contextMenuInstance = new RenderFragment(builder => {
                builder.OpenComponent<MudContextMenu>(0);
                builder.SetKey(contextMenuRef.Id);
                builder.AddAttribute(1, "Id", contextMenuRef.Id);
                builder.AddAttribute(2, "Content", contextMenuContent);
                builder.AddAttribute(3, "X", x);
                builder.AddAttribute(4, "Y", y);
                builder.CloseComponent();
            });

            contextMenuRef.InjectContent(contextMenuInstance);
            OnInstanceAdded?.Invoke(contextMenuRef);

            return contextMenuRef;
        }

        public void Close(Guid id) => OnInstanceCloseRequested?.Invoke(id);
    }
}
