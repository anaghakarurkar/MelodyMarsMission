using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    internal class MarsRover : IRover
    {
        public Position CurrentPosition { get; private set; }
        public Position FinalPosition { get; private set; }
        public string PathString { get; private set; }
        public bool IsLandedOnPlateau { get; private set; }
        public Directions CurrentDirection { get; set; }

        public MarsRover()
        {
            CurrentPosition = new();
            FinalPosition = new();
            PathString = "";
        }

        public void CheckForObstacles()
        {

        }


        private string Move()
        {
            return "";
        }

        private void Move(Directions direction)
        {
            CurrentDirection = direction;
        }


        /* Moves rover according to instructions provided.
        It returns final co-ordinates with its direction.
        In case of Obstacle, it returns error message*/
        public string Move(string instructions)
        {

            return " df";
        }


        // Sets rover on plateau using co-ordinates provided and direction.
        public void SetLocationAndDirection(Position position, Directions direction)
        {
            CurrentPosition = position;
            CurrentDirection = direction;
            IsLandedOnPlateau = true;
        }
    }
}