using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MarsMission
{
    public class MissionControl
    {
        public List<IRover> RoversInPlateau { get; set; }

        public Plateau ChosenPlateau { get; private set; }


        public MissionControl(Position maxGridSize)
        {
            RoversInPlateau = new List<IRover>();
            RoversInPlateau.Add(new SpiritRover());
            if (maxGridSize == null || ((maxGridSize.X <=0 || maxGridSize.X >5) || (maxGridSize.Y <= 0 || maxGridSize.Y > 5)))
            {
                maxGridSize = new Position(5, 5);
            }
            ChosenPlateau = new Plateau(maxGridSize);
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