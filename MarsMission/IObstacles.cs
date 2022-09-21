using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IObstacles
    {
        string Name { get;  set; }
        Position CurrentPostion { get;  set; }
    }
}