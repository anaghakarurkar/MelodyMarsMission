using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Obstacle : IObstacles
    {
        public string Name { get; set; }
        public Position CurrentPostion { get; set; }
        public Obstacle(string name, Position currentPostion)
        {
            Name = name;
            CurrentPostion = currentPostion;
        }
    }
}