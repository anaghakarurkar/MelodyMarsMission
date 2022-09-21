using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Alien : IObstacles
    {
         public string Name { get;  set; }
        public Position CurrentPostion { get;  set; }
        public Alien(string name, Position currentPostion)
        {
            Name = name;
            CurrentPostion = currentPostion;
        }
    }
}