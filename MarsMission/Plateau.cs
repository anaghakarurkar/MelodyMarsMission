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
        public Position MacCoordinates { get; set; }
        public List<IObstacles> ObstaclesList { get; set; }
        public Position[][] Grid { get; set; }

        public Plateau(Position maxPosition)
        {
            Grid = new Position[maxPosition.X][];
            CurrentDirection = Directions.N;
            StartCoordinates = new Position(0, 0);
            MacCoordinates = maxPosition;
            ObstaclesList = new List<IObstacles>();
        }

    }
}