using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGameOfLife
{
    public class CellLife
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int PreviousState { get; set; }
        public int CurrentState { get; set; }
    }
}
