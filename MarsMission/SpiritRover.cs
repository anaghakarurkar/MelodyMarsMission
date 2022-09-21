using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class SpiritRover : IRover
    {
        public string Name { get; set; }
        public Position CurrentPosition { get; set; }
        public Position FinalPosition { get; set; }
        public string PathString { get ; set ; }

        public SpiritRover(): this(0, 0) { }
        
        public SpiritRover(int x, int y,  string pathStr = "Spirit")
        {
            Name = "Sprit";
            CurrentPosition = new(x, y);
            FinalPosition = new();
            PathString = pathStr;
        }
        public void CheckForObstacles()
        {

        }


        public string Move()
        {
            return "";
        }

        public void MoveLeft(string info)
        {

        }

        public void MoveRight(string info)
        {

        }

        void IRover.Move(string instructions)
        {
            throw new NotImplementedException();
        }
    }
}