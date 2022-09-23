using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Plateau : IPlateau
    {
        public Position StartCoordinates { get; private set; }
        public Position MaxCoordinates { get; private set; }
        public List<IRover>? RoversInPlateau { get; set; }
        public List<IObstacles> ObstaclesList { get; set; }

        public Plateau(Position maxPosition)
        {
            StartCoordinates = new Position(0, 0);
            MaxCoordinates = maxPosition;
            ObstaclesList = new List<IObstacles>();
        }

    }
}