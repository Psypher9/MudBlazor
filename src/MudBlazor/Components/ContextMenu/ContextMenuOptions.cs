using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor
{
    public class ContextMenuOptions
    {
        /// <summary>
        /// The X coordinate of the mouse pointer in local (DOM content) coordinates.
        /// </summary>
        public int ClientX { get; set; }

        /// <summary>
        /// The Y coordinate of the mouse pointer in local (DOM content) coordinates.
        /// </summary>
        public int ClientY { get; set; }

        /// <summary>
        /// The X coordinate of the mouse pointer in relative(Target Element) coordinates.
        /// </summary>
        public int OffsetX { get; set; }

        /// <summary>
        /// The Y coordinate of the mouse pointer in relative (Target Element) coordinates.
        /// </summary>
        public int OffsetY { get; set; }        
    }
}
