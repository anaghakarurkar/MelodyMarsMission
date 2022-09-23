using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            ChosenPlateau = new Plateau(maxGridSize)
            {
                RoversInPlateau = new List<IRover>
                {
                new MarsRover("spirit"),
                new MarsRover("opportunity")
                }
            };
        }
        public bool LandRoverOnLocation(Position position, Directions direction)
        {
            if (position.X > ChosenPlateau.MaxCoordinates.X || position.Y > ChosenPlateau.MaxCoordinates.Y)
                return false;
            else
            {
                ChosenPlateau.RoversInPlateau?[0].SetLocationAndDirection(position, direction);
                return true;
            }
        }


        public Position GetCurrentRoverPosition(IRover rover)
        {
            throw new System.NotImplementedException();
        }

        public string SendMessageToRover(string name, string message)
        {
            string finalPath = "";
            name = name.ToLower();

            if (String.IsNullOrEmpty(name))
            {
                return name + " rover does not exist";
            }
            if (name == "spirit")
            {
                finalPath = ChosenPlateau.RoversInPlateau?[0].Move(message);
            }
            return finalPath;
        }

    }
}