using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class MarsRover : IRover
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public Position CurrentPosition { get; set; }
        public Position FinalPosition { get; set; }
        public string PathString { get; set; }
        public bool IsLandedOnPlateau { get; set; }
        public Directions CurrentDirection { get; set; }

        public MarsRover(string name)
        {
            _name = name;
            CurrentPosition = new();
            FinalPosition = new();
            PathString = "";
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