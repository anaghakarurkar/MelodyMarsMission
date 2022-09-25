using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public interface IObstacle
    {
        string Name { get; set; }
        Position CurrentPosition { get; set; }
    }
}