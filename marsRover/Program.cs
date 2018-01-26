using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    class Program{
        static void Main(string[] args){
            RoverInterface theRoversInterface = new RoverInterface();
            theRoversInterface.gridInterface();
            theRoversInterface.roverLaunchingInterface();
        }
    }
}
