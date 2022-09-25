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
        Focus CurrentFocus { get; set; }

        string Move(string instructions, Position maxGridSize, Func<Position, bool> checkObstacleMethodRef);
        void SetLocationAndDirection(Position position, Focus direction);
    }
}