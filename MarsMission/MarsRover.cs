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

        private Func<Position, bool>? CheckObstacles;
        public MarsRover()
        {
            CurrentPosition = new();
            FinalPosition = new();
            PathString = "";
            NewDirection = new();
        }

        private Position Move(Focus direction, Position lastPosition, Position maxGridSize)
        {
            //This function checks two things:
            //1. While moving if obstacle found in next location, rover does not move there.
            //2. Rover does not go out of grid while moving
            switch (direction)
            {
                case Focus.E:
                    //Check if obstacle found - rover does not move there
                    if ((CheckObstacles != null) && CheckObstacles(new Position(lastPosition.X + 1, lastPosition.Y)) == true)
                        return lastPosition;
                    //If no obstacle found rover moves
                    lastPosition.X = (lastPosition.X != maxGridSize.X) ? lastPosition.X += 1 : lastPosition.X;
                    break;
                case Focus.W:
                    if ((CheckObstacles != null) && CheckObstacles(new Position(lastPosition.X - 1, lastPosition.Y)) == true)
                        return lastPosition;
                    lastPosition.X = (lastPosition.X != 0) ? lastPosition.X -= 1 : lastPosition.X;
                    break;
                case Focus.N:
                    if ((CheckObstacles != null) && CheckObstacles(new Position(lastPosition.X, lastPosition.Y + 1)) == true)
                        return lastPosition;
                    lastPosition.Y = (lastPosition.Y != maxGridSize.Y) ? lastPosition.Y += 1 : lastPosition.Y;
                    break;
                case Focus.S:
                    if ((CheckObstacles != null) && CheckObstacles(new Position(lastPosition.X, lastPosition.Y - 1)) == true)
                        return lastPosition;
                    lastPosition.Y = (lastPosition.Y != 0) ? lastPosition.Y -= 1 : lastPosition.Y;
                    break;
            }

            // return updated position
            return lastPosition;
        }


        /* Moves rover according to instructions provided.
        It returns final co-ordinates with its direction.
        In case of Obstacle, it returns invalid co-ordinates. 
        */
        public string Move(string instructions, Position maxGridSize, Func<Position, bool> checkObstacleMethodRef)
        {
            this.CheckObstacles = checkObstacleMethodRef;

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