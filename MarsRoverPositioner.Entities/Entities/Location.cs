using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPositioner.Business.Entities
    {/// <summary>
    /// Stores the coordinates that describe the position on the grid
    /// </summary>
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Heading { get; set; }

        public override string ToString()
        {
            return $"Location-> X:{X} Y:{Y} Heading: {Heading}";
        }
    }
}
