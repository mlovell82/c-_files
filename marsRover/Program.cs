using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid sampleGrid = new Grid(5, 6);
            Rovers theRovers = new Rovers();
            sampleGrid.gridInterface();
            theRovers.roversInterface();

        }
    }
}
