using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IRover
    {
        int Name { get; set; }
        int CurrentPosition { get; set; }
        int FinalPosition { get; set; }

        void Move(string instructions);
        void MoveLeft(string info);
        void MoveRight(string info);
        void CheckForObstacles();
    }
}