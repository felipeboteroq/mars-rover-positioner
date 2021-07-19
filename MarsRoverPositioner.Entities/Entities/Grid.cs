using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPositioner.Business.Entities
{
    /// <summary>
    /// Describes a rectangular plateau with X,Y coordinates 
    /// </summary>
    public class Grid
    {
        public Grid(int xBoundary, int yBoundary)
        {
            this.XBoundary = xBoundary;
            this.YBoundary = yBoundary;
        }
        public int XBoundary { get; }
        public int YBoundary { get; }
    }
}
