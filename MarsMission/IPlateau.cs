using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IPlateau
    { 
        Position StartCoordinates { get;}
        Position MaxCoordinates { get;}
        List<IObstacles> ObstaclesList { get; set; }
    
        public List<IRover>? RoversInPlateau { get; set; }
    }
}