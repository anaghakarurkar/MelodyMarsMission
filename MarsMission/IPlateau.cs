using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IPlateau
    {
        Position Grid { get; set; }
        Position StartCoordinates { get; set; }
        Directions CurrentPosition { get; set; }
        System.Collections.Generic.List<IObstacles> ObstaclesList { get; set; }
    }
}