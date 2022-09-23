using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IRover
    {
        string Name { get; }
        Position CurrentPosition { get; }
        Position FinalPosition { get; }
        string PathString { get; }
        bool IsLandedOnPlateau { get; set; }
        Directions CurrentDirection { get; set; }

        string Move(string instructions);
        void CheckForObstacles();
        void SetLocationAndDirection(Position position, Directions direction);
    }
}