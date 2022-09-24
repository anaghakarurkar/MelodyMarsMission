using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        public bool LandRoverOnLocation(string name, Position position, Directions direction)
        {
            if (position.X > ChosenPlateau.MaxCoordinates.X || position.Y > ChosenPlateau.MaxCoordinates.Y)
                return false;

            if (CheckRoverExists(name))
            {
                //add more checks if another rover is already there on that location
                //throw specific exceptions
                // check if location has alien then return flase
                //then error will be can not set rover in specified position
                ChosenPlateau.RoversInPlateau[name].SetLocationAndDirection(position, direction);
            }
            return true;

        }

        public Position GetCurrentRoverPosition(IRover rover)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckRoverExists(string name)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(name))
            {
                result = ChosenPlateau.RoversInPlateau.ContainsKey(name.ToLower());
            }

            return result;
        }
        private static bool CheckForMessageValidity(string message)
        {
            bool result = false;
            Regex regex = new("^[LMR]$");

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