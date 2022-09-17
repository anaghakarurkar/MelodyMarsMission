using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class RectPlateau : IPlateau
    {
                        public RectPlateau()
        {
            throw new System.NotImplementedException();
        }

        Position IPlateau.Grid { get; set; }
        Position IPlateau.StartCoordinates { get; set; }
        Directions IPlateau.CurrentPosition { get; set; }
        List<IObstacles> IPlateau.ObstaclesList { get; set; }

       
    }
}