using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class Boulder : IObstacles
    {
        public Boulder()
        {
            throw new System.NotImplementedException();
        }

        string IObstacles.Name { get ; set; }
        Position IObstacles.CurrentPostion { get;set; }
        
    }
}