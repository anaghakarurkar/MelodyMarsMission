using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MarsMission
{
    public class MissionControl
    {
        public List<IRover> RoversInPlateau { get; set; }
        

        public MissionControl()
        {
            RoversInPlateau = new List<IRover>();
            
            RoversInPlateau.Add(new SpiritRover(0,0,""));
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

        public void SetPlateauGrid()
        {
            throw new System.NotImplementedException();
        }
    }
}