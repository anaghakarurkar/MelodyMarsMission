using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MarsMission.Exceptions;

namespace MarsMission
{
    public class MissionControl
    {
        public IPlateau ChosenPlateau { get; private set; }
        public MissionControl(Position maxGridSize)
        {
            if (maxGridSize == null || ((maxGridSize.X <= 0 || maxGridSize.X > 5) || (maxGridSize.Y <= 0 || maxGridSize.Y > 5)))
            {
                maxGridSize = new Position(5, 5);
            }
            ChosenPlateau = new Plateau(maxGridSize);
        }
        public void LandRoverOnLocation(string name, Position position, Directions direction)
        {

            if (CheckRoverPositionValidity(position) == false)
              throw new RoverLandingException("Invalid Co-ordinates.");

            if (CheckRoverExists(name) == false)
              throw new RoverLandingException("Rover name does not exist.");

            if (CheckForObstacles(position) == false)
              throw new RoverLandingException("Obstacle found.");
               
               ChosenPlateau.RoversInPlateau[name].SetLocationAndDirection(position, direction);
        }



        public Position GetCurrentRoverPosition(IRover rover)
        {
            throw new System.NotImplementedException();
        }

      
        public bool CheckRoverPositionValidity(Position position)
        {
            return ((position == null) || (position.X > ChosenPlateau.MaxCoordinates.X || position.Y > ChosenPlateau.MaxCoordinates.Y));   
        }

        public bool CheckForObstacles(Position position)
        {
            //check if another rover 
            //or other obstacle is already at this position
            return ChosenPlateau.RoversInPlateau.Where(rover => (rover.Value.CurrentPosition.X == position.X) && (rover.Value.CurrentPosition.Y == position.Y)).Any() ||
                   ChosenPlateau.ObstaclesList.Where(obstacle => (obstacle.CurrentPosition.X == position.X) && (obstacle.CurrentPosition.Y == position.Y)).Any();
            //var isRoverFound = (from c in ChosenPlateau.RoversInPlateau
            //             where (c.Value.CurrentPosition.X == position.X) && (c.Value.CurrentPosition.Y == position.Y)
            //             select c).Any();
            
           
            //var isObstacleFound = (from obstacle in ChosenPlateau.ObstaclesList
            //                where(obstacle.CurrentPosition.X == position.X) && (obstacle.CurrentPosition.Y == position.Y)
            //                select obstacle).Any();
            
            //return isRoverFound || isObstacleFound;
        }
        public bool CheckRoverExists(string name)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(name))
            {
                result = ChosenPlateau.RoversInPlateau.ContainsKey(name.ToLower());
            }

            return result;
        }
        public bool CheckForMessageValidity(string message)
        {
            bool result = false;
            Regex regex = new("^[LMRlrm]*$");

            if (!String.IsNullOrEmpty(message) && regex.IsMatch(message))
                result = true;

            return result;
        }
        public string SendMessageToRover(string name, string message)
        {
            string finalPath;
            if (CheckRoverExists(name) == false)
                return name + " rover does not exist";
            if (CheckForMessageValidity(message))
                return message + " is invalid message";

            finalPath = ChosenPlateau.RoversInPlateau[name].Move(message);
            return finalPath;
        }

    }
}