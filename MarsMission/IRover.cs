using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IRover
    {
        string Name { get; set; }
        Position CurrentPosition { get; set; }
        Position FinalPosition { get; set; }

        void Move(string instructions);
        void MoveLeft(string info);
        void MoveRight(string info);
        void CheckForObstacles();
    }
}