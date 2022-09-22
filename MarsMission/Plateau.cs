using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Plateau : IPlateau
    {

        public Position StartCoordinates { get; set; }
        public Directions CurrentDirection { get; set; }
        public Position MaxCoordinates { get; set; }
        public List<IObstacles> ObstaclesList { get; set; }
        public Position[][] Grid { get; set; }

        public Plateau(Position maxPosition)
        {
            Grid = new Position[maxPosition.X][];
            CurrentDirection = Directions.N;
            StartCoordinates = new Position(0, 0);
            MaxCoordinates = maxPosition;
            ObstaclesList = new List<IObstacles>();
        }

    }
}