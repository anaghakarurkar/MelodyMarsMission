using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class MissionControl
    {
        public System.Collections.Generic.List<IRover> RoversInPlateau
        {
            get => default;
            set
            {
            }
        }

        public bool LandRoverOnLocation(Position position, Directions direction) 
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveRoverFromPlateau(IRover rover) 
        {
            throw new System.NotImplementedException();
        }

        public Position GetCurrentRoverPosition(IRover rover)
        {
            throw new System.NotImplementedException();
        }

        public bool SendMessageToRover(IRover rover, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}