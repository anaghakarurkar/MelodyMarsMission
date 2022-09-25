using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IPlateau
    { 
        Position StartCoordinates { get;}
        Position MaxCoordinates { get;  }
        List<IObstacle> ObstaclesList { get; }
        public Dictionary<string, IRover> RoversInPlateau { get; }
    }
}