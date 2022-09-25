using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    internal class MarsRover : IRover
    {
        // To track rover's location  
        public Position CurrentPosition { get; private set; }
        public Position FinalPosition { get; private set; }
        public string PathString { get; private set; }
        public bool IsLandedOnPlateau { get; private set; }
        public Focus CurrentFocus { get; set; }
        public ChangeFocus NewDirection { get; }

        public MarsRover()
        {
            CurrentPosition = new();
            FinalPosition = new();
            PathString = "";
            NewDirection = new();
        }

        public void CheckForObstacles()
        {

        }


        private string Move()
        {
            return "";
        }

        private Position Move(Focus direction, Position lastPosition, Position maxGridSize)
        {
            //Check if next location is
            //1. Obstacle like another rover or alien
            //2. Check if next move is out of the grid
            switch (direction)
            {
                case Focus.E:
                    lastPosition.X = (lastPosition.X != maxGridSize.X) ? lastPosition.X += 1 : lastPosition.X;
                    break;
                case Focus.W:
                    lastPosition.X = (lastPosition.X != 0) ? lastPosition.X -= 1 : lastPosition.X;
                    break;
                case Focus.N:
                    lastPosition.Y = (lastPosition.Y != maxGridSize.Y) ? lastPosition.Y += 1 : lastPosition.Y;
                    break;
                case Focus.S:
                    lastPosition.Y = (lastPosition.Y != 0) ? lastPosition.Y -= 1 : lastPosition.Y;
                    break;
            }

            // return updated position
            return lastPosition;
        }


        /* Moves rover according to instructions provided.
        It returns final co-ordinates with its direction.
        In case of Obstacle, it returns error message*/
        public string Move(string instructions, Position maxGridSize)
        {
            //Add logic to see if 
            foreach (char step in instructions.ToCharArray())
            {
                switch (step)
                {
                    case 'L':
                    case 'R':
                        CurrentFocus = NewDirection.GetDirection(CurrentFocus, step);
                        break;
                    case 'M':
                        CurrentPosition = Move(CurrentFocus, CurrentPosition, maxGridSize);
                        break;
                }

            }

            return $"{CurrentPosition.X} {CurrentPosition.Y} {CurrentFocus.ToString()}";
        }


        // Sets rover on plateau using co-ordinates provided and direction.
        public void SetLocationAndDirection(Position position, Focus direction)
        {
            CurrentPosition = position;
            CurrentFocus = direction;
            IsLandedOnPlateau = true;
        }
    }
}