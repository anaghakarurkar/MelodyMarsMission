using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IRover
    {
        Position CurrentPosition { get; }
        Position FinalPosition { get; }
        string PathString { get; }
        bool IsLandedOnPlateau { get; }
        Directions CurrentDirection { get; set; }

        string Move(string instructions);
        void CheckForObstacles();
        void SetLocationAndDirection(Position position, Directions direction);
    }
}