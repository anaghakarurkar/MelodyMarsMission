using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class SpiritRover : IRover
    {
        string IRover.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Position IRover.CurrentPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Position IRover.FinalPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void IRover.CheckForObstacles()
        {
            throw new NotImplementedException();
        }

   
        void IRover.Move(string instructions)
        {
            throw new NotImplementedException();
        }

        void IRover.MoveLeft(string info)
        {
            throw new NotImplementedException();
        }

        void IRover.MoveRight(string info)
        {
            throw new NotImplementedException();
        }
    }
}