using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IPlateau
    {
        MarsMission.Position[][] Grid { get; set; }
        Position StartCoordinates { get; set; }
        Directions CurrentDirection { get; set; }
        List<IObstacles> ObstaclesList { get; set; }
        Position MaxCoordinates { get; set; }
    }
}