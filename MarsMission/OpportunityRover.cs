using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class OpportunityRover : IRover
    {
        public string PathString { get; set; }
        public string Name { get; set; }
        public Position CurrentPosition { get; set; }
        public Position FinalPosition { get; set; }


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