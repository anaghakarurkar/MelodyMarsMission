using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IRover
    {
        string Name { get; }
        Position CurrentPosition { get; set; }
        Position FinalPosition { get; set; }
        string PathString { get; set; }
        bool IsLandedOnPlateau { get; set; }
        Directions CurrentDirection { get; set; }

        /// <returns>string</returns>
        string Move(string instructions);
        void CheckForObstacles();
        void SetLocationAndDirection(Position position, Directions direction);
    }
}