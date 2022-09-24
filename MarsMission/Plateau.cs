﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Plateau : IPlateau
    {
        public Position StartCoordinates { get; private set; }
        public Position MaxCoordinates { get; private set; }
        public Dictionary<string, IRover> RoversInPlateau { get; private set; }
        public List<IObstacles> ObstaclesList { get; private set; }

        public const string spirit = "spirit";
        public const string opportunity = "opportunity";
        public const string alien = "alien";
        public Plateau(Position maxPosition)
        {
            Random random = new Random();
            StartCoordinates = new Position(0, 0);
            MaxCoordinates = maxPosition;
            ObstaclesList = new List<IObstacles>();

            //Creating two rovers and adding them in Plateau
            RoversInPlateau = new Dictionary<string, IRover>
                {
                    {spirit,new MarsRover() },
                    {opportunity, new MarsRover()}
                };

            //Adding Obstacle at random position in grid
            ObstaclesList = new List<IObstacles>
            {
                { //new Obstacle(alien, new Position(random.Next(0, maxPosition.X),random.Next(0, maxPosition.Y)))
                  new Obstacle(alien, new Position(1,1))
                }
             };
        }

    }
}