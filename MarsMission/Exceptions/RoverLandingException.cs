using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsMission.Exceptions
{
    public class RoverLandingException: Exception
    {
        public RoverLandingException(string message) : base($"Rover landing cancelled: {message}") { }
    }
}
