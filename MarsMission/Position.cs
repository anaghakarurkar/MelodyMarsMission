using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position() : this(0, 0) { }
        public Position(int x, int y)
        {
            // initialise position co-ordinates
            X = x;
            Y = y;
        }

    }
}